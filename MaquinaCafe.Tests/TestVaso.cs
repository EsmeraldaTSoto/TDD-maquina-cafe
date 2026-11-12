using MaquinaCafe;
using Xunit;

namespace MaquinaCafe.Tests;

// Pruebas de la clase Vaso
public class TestVaso
{
    // Si hay 2 vasos y pido 1, tiene que decir que sí hay
    [Fact]
    public void DeberiaDevolverVerdaderoSiExistenVasos()
    {
        Vaso vasosPequenos = new Vaso(2, 10);

        bool resultado = vasosPequenos.HasVasos(1);

        Assert.True(resultado);
    }

    // Si hay 1 vaso y pido 2, tiene que decir que no hay
    [Fact]
    public void DeberiaDevolverFalsoSiNoExistenVasos()
    {
        Vaso vasosPequenos = new Vaso(1, 10);

        bool resultado = vasosPequenos.HasVasos(2);

        Assert.False(resultado);
    }

    // Si hay 5 vasos y doy 1, tienen que quedar 4
    [Fact]
    public void DeberiaRestarCantidadDeVaso()
    {
        Vaso vasosPequenos = new Vaso(5, 10);

        vasosPequenos.GiveVasos(1);

        Assert.Equal(4, vasosPequenos.GetCantidadVasos());
    }
}