## Segundo parcial 

## Autor

Esmeralda Soto | 2024-1861

# Proyecto TDD: Máquina de Café

Proyecto de C# desarrollado con la metodología TDD (Test-Driven Development), con un flujo básico de integración continua usando GitHub Actions.

## Descripción

Simula una máquina de café que sirve vasos de tres tamaños (pequeño, mediano y grande). Antes de servir, verifica que haya vasos, café y azúcar suficientes, y devuelve un mensaje según el resultado ("No hay Vasos", "No hay Cafe", "No hay Azucar" o "Felicitaciones").

## Clases

- `Cafetera`: controla la cantidad de café disponible.
- `Vaso`: controla los vasos disponibles y el café que lleva cada tamaño.
- `Azucarero`: controla la cantidad de azúcar disponible.
- `MaquinaDeCafe`: junta las demás clases y sirve el café.

## Estructura

```
MaquinaCafeSolucion.slnx
├── MaquinaCafe/          # Código fuente
├── MaquinaCafe.Tests/    # Pruebas unitarias (xUnit)
└── .github/workflows/
    └── ci-pipeline.yml   # Pipeline de CI
```

## Ejecutar las pruebas

```bash
dotnet test MaquinaCafeSolucion.slnx
```

## Integración continua

El workflow `ci-pipeline.yml` se ejecuta con cada `push` y `pull_request`: clona el repositorio, configura el entorno y compila el proyecto.

## Control de versiones

- `main`: versión estable.
- `develop`: integración del desarrollo.
- `feature/*`: nuevas funcionalidades (por ejemplo, `feature/ci-pipeline`).
