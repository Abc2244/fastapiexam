from fastapi import FastAPI
from Routes.routes import router as EmpleadoRouter  # Asegúrate de que este import sea correcto
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()

origins = [
    "http://localhost:5129",
]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["POST", "GET", "PUT", "DELETE"],
    allow_headers=["*"],
)

# Include routers
app.include_router(EmpleadoRouter, tags=["Empleados"], prefix="/api/v1")  # Cambiado a Empleados

@app.get("/", tags=["Root"])
async def read_root():
    return {"message": "Welcome to this fantastic app!"}
