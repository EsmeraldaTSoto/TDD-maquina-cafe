using MaquinaCafe;
using Xunit;

namespace MaquinaCafe.Tests;

// Pruebas de la clase Cafetera
public class TestCafetera
{
    // Si hay 10 de café y pido 5, tiene que decir que sí hay
    [Fact]
    public void DeberiaDevolverVerdaderoSiExisteCafe()
    {
        Cafetera cafetera = new Cafetera(10);

        bool resultado = cafetera.HasCafe(5);

        Assert.True(resultado);
    }

    // Si hay 10 de café y pido 11, tiene que decir que no hay
    [Fact]
    public void DeberiaDevolverFalsoSiNoExisteCafe()
    {
        Cafetera cafetera = new Cafetera(10);

        bool resultado = cafetera.HasCafe(11);

        Assert.False(resultado);
    }

    // Si hay 10 de café y saco 7, tienen que quedar 3
    [Fact]
    public void DeberiaRestarCafeALaCafetera()
    {
        Cafetera cafetera = new Cafetera(10);

        cafetera.GiveCafe(7);

        Assert.Equal(3, cafetera.GetCantidadCafe());
    }
}