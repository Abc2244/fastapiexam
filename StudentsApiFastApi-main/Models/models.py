from sqlalchemy import Column, Integer, String, ForeignKey, create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship

Base = declarative_base()

class Cargo(Base):
    __tablename__ = "CARGO"

    IdCargo = Column(Integer, primary_key=True, index=True)
    Descripcion = Column(String(50))

class Empleado(Base):
    __tablename__ = "EMPLEADO"

    IdEmpleado = Column(Integer, primary_key=True, index=True)
    NombreCompleto = Column(String(60))
    Correo = Column(String(60))
    Telefono = Column(String(60))
    IdCargo = Column(Integer, ForeignKey("CARGO.IdCargo"))
    
    cargo = relationship("Cargo")
