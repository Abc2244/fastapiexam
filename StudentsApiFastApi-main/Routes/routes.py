from fastapi import APIRouter, HTTPException
from fastapi.responses import JSONResponse
from Models.models import Empleado as EmpleadoModel
from Schemas.schemas import EmpleadoCreate, Empleado as EmpleadoSchema
from Config.database import SessionLocal

router = APIRouter()

@router.get("/empleados", tags=["Empleados"])
async def get_all_empleados():
    try:
        empleados = SessionLocal().query(EmpleadoModel).all()
        return empleados
    except Exception as e:
        return JSONResponse(status_code=500, content={"error": "Internal Server Error", "detail": str(e)})

@router.get("/empleados/{id}", tags=["Empleados"])
async def get_empleado_by_id(id: int):
    try:
        empleado = SessionLocal().query(EmpleadoModel).filter(EmpleadoModel.IdEmpleado == id).first()
        if empleado is None:
            raise HTTPException(status_code=404, detail="Empleado not found")
        return empleado
    except HTTPException as http_exc:
        raise http_exc
    except Exception as e:
        return JSONResponse(status_code=500, content={"error": "Internal Server Error", "detail": str(e)})

@router.post("/empleados", tags=["Empleados"])
async def create_empleado(empleado: EmpleadoCreate):
    session = SessionLocal()
    try:
        new_empleado = EmpleadoModel(
            NombreCompleto=empleado.NombreCompleto,
            Correo=empleado.Correo,
            Telefono=empleado.Telefono,
            IdCargo=empleado.IdCargo
        )
        session.add(new_empleado)
        session.commit()
        session.refresh(new_empleado)
        return new_empleado
    except HTTPException as http_exc:
        session.rollback()
        raise http_exc
    except Exception as e:
        return JSONResponse(status_code=500, content={"error": "Internal Server Error", "detail": str(e)})
    finally:
        session.close()

@router.put("/empleados/{id}", tags=["Empleados"])
async def update_empleado(id: int, empleado: EmpleadoCreate):
    session = SessionLocal()
    try:
        existing_empleado = session.query(EmpleadoModel).filter(EmpleadoModel.IdEmpleado == id).first()
        if existing_empleado is None:
            raise HTTPException(status_code=404, detail="Empleado not found")
        existing_empleado.NombreCompleto = empleado.NombreCompleto
        existing_empleado.Correo = empleado.Correo
        existing_empleado.Telefono = empleado.Telefono
        existing_empleado.IdCargo = empleado.IdCargo
        session.commit()
        session.refresh(existing_empleado)
        return existing_empleado
    except HTTPException as http_exc:
        session.rollback()
        raise http_exc
    except Exception as e:
        return JSONResponse(status_code=500, content={"error": "Internal Server Error", "detail": str(e)})
    finally:
        session.close()

@router.delete("/empleados/{id}", tags=["Empleados"])
async def delete_empleado(id: int):
    session = SessionLocal()
    try:
        existing_empleado = session.query(EmpleadoModel).filter(EmpleadoModel.IdEmpleado == id).first()
        if existing_empleado is None:
            raise HTTPException(status_code=404, detail="Empleado not found")
        session.delete(existing_empleado)
        session.commit()
        return {"message": "Empleado deleted"}
    except HTTPException as http_exc:
        session.rollback()
        raise http_exc
    except Exception as e:
        return JSONResponse(status_code=500, content={"error": "Internal Server Error", "detail": str(e)})
    finally:
        session.close()
