from pydantic import BaseModel

class CargoBase(BaseModel):
    Descripcion: str

class CargoCreate(CargoBase):
    pass

class Cargo(CargoBase):
    IdCargo: int

    class Config:
        orm_mode = True

class EmpleadoBase(BaseModel):
    NombreCompleto: str
    Correo: str
    Telefono: str
    IdCargo: int

class EmpleadoCreate(EmpleadoBase):
    pass

class Empleado(EmpleadoBase):
    IdEmpleado: int

    class Config:
        orm_mode = True
