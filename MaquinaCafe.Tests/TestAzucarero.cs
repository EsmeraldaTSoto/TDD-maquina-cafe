using MaquinaCafe;
using Xunit;

namespace MaquinaCafe.Tests;

// Pruebas de la clase Azucarero
public class TestAzucarero
{
    private readonly Azucarero azucarero;

    // Esto se ejecuta antes de cada prueba y crea un azucarero nuevo con 10 de azúcar.
    // Así cada prueba empieza desde cero y no se mezclan entre ellas.
    public TestAzucarero()
    {
        azucarero = new Azucarero(10);
    }

    // Con 10 de azúcar, pedir 5 o pedir 10 tiene que decir que sí hay
    [Fact]
    public void DeberiaDevolverVerdaderoSiHaySuficienteAzucarEnElAzucarero()
    {
        bool resultado = azucarero.HasAzucar(5);

        Assert.True(resultado);

        resultado = azucarero.HasAzucar(10);

        Assert.True(resultado);
    }

    // Con 10 de azúcar, pedir 15 tiene que decir que no hay
    [Fact]
    public void DeberiaDevolverFalsoPorqueNoHaySuficienteAzucarEnElAzucarero()
    {
        bool resultado = azucarero.HasAzucar(15);

        Assert.False(resultado);
    }

    // Con 10 de azúcar, si saco 5 quedan 5, y si saco 2 más quedan 3
    [Fact]
    public void DeberiaRestarAzucarAlAzucarero()
    {
        azucarero.GiveAzucar(5);

        Assert.Equal(5, azucarero.GetCantidadAzucar());

        azucarero.GiveAzucar(2);

        Assert.Equal(3, azucarero.GetCantidadAzucar());
    }
}