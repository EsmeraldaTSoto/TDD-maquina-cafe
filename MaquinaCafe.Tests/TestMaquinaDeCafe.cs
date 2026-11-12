using MaquinaCafe;
using Xunit;

namespace MaquinaCafe.Tests;

// Pruebas de la clase MaquinaDeCafe
public class TestMaquinaDeCafe
{
    private readonly Cafetera cafetera;
    private readonly Vaso vasosPequeno;
    private readonly Vaso vasosMediano;
    private readonly Vaso vasosGrande;
    private readonly Azucarero azucarero;
    private readonly MaquinaDeCafe maquinaDeCafe;

    // Esto se ejecuta antes de cada prueba y arma una máquina nueva con todo lleno:
    // 50 de café, 5 vasos de cada tamaño (10, 20 y 30 de café) y 20 de azúcar.
    public TestMaquinaDeCafe()
    {
        cafetera = new Cafetera(50);
        vasosPequeno = new Vaso(5, 10);
        vasosMediano = new Vaso(5, 20);
        vasosGrande = new Vaso(5, 30);
        azucarero = new Azucarero(20);

        maquinaDeCafe = new MaquinaDeCafe();
        maquinaDeCafe.Cafetera = cafetera;
        maquinaDeCafe.VasosPequeno = vasosPequeno;
        maquinaDeCafe.VasosMediano = vasosMediano;
        maquinaDeCafe.VasosGrande = vasosGrande;
        maquinaDeCafe.Azucarero = azucarero;
    }

    // Si pido un vaso "pequeno", me tiene que dar el vaso pequeño.
    // Assert.Same revisa que sea exactamente el mismo objeto.
    [Fact]
    public void DeberiaDevolverUnVasoPequeno()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        Assert.Same(maquinaDeCafe.VasosPequeno, vaso);
    }

    // Si pido un vaso "mediano", me tiene que dar el mediano
    [Fact]
    public void DeberiaDevolverUnVasoMediano()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("mediano");

        Assert.Same(maquinaDeCafe.VasosMediano, vaso);
    }

    // Si pido un vaso "grande", me tiene que dar el grande
    [Fact]
    public void DeberiaDevolverUnVasoGrande()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("grande");

        Assert.Same(maquinaDeCafe.VasosGrande, vaso);
    }

    // Hay 5 vasos pequeños y pido 10, así que tiene que avisar que no hay vasos
    [Fact]
    public void DeberiaDevolverNoHayVasos()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 10, 2);

        Assert.Equal("No hay Vasos", resultado);
    }

    // Pongo una cafetera con solo 5 de café (un vaso pequeño necesita 10),
    // así que tiene que avisar que no hay café
    [Fact]
    public void DeberiaDevolverNoHayCafe()
    {
        Cafetera cafeteraSinCafe = new Cafetera(5);
        maquinaDeCafe.Cafetera = cafeteraSinCafe;

        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 2);

        Assert.Equal("No hay Cafe", resultado);
    }

    // Pongo un azucarero con solo 2 de azúcar y pido 3,
    // así que tiene que avisar que no hay azúcar
    [Fact]
    public void DeberiaDevolverNoHayAzucar()
    {
        Azucarero azucareroSinAzucar = new Azucarero(2);
        maquinaDeCafe.Azucarero = azucareroSinAzucar;

        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        Assert.Equal("No hay Azucar", resultado);
    }

    // Había 50 de café y el vaso pequeño gasta 10, así que tienen que quedar 40
    [Fact]
    public void DeberiaRestarCafe()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        int resultado = maquinaDeCafe.Cafetera.GetCantidadCafe();

        Assert.Equal(40, resultado);
    }

    // Había 5 vasos pequeños y se usó 1, así que tienen que quedar 4
    [Fact]
    public void DeberiaRestarVaso()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        int resultado = maquinaDeCafe.VasosPequeno.GetCantidadVasos();

        Assert.Equal(4, resultado);
    }

    // Había 20 de azúcar y se pidieron 3 cucharadas, así que tienen que quedar 17
    [Fact]
    public void DeberiaRestarAzucar()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        int resultado = maquinaDeCafe.Azucarero.GetCantidadAzucar();

        Assert.Equal(17, resultado);
    }

    // Si todo sale bien (hay vasos, café y azúcar), tiene que devolver "Felicitaciones"
    [Fact]
    public void DeberiaDevolverFelicitaciones()
    {
        Vaso vaso = maquinaDeCafe.GetTipoDeVaso("pequeno");

        string resultado = maquinaDeCafe.GetVasoDeCafe(vaso, 1, 3);

        Assert.Equal("Felicitaciones", resultado);
    }
}