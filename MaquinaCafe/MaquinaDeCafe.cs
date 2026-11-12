namespace MaquinaCafe;

// Esta es la clase principal. Junta la cafetera, los vasos y el azucarero
// para poder servir un café.
public class MaquinaDeCafe
{
    // Mensajes que devuelve la máquina. Los puse aquí para no repetir los textos.
    private const string MensajeNoHayVasos = "No hay Vasos";
    private const string MensajeNoHayCafe = "No hay Cafe";
    private const string MensajeNoHayAzucar = "No hay Azucar";
    private const string MensajeExito = "Felicitaciones";

    // Las partes de la máquina
    public Cafetera Cafetera { get; set; }
    public Vaso VasosPequeno { get; set; }
    public Vaso VasosMediano { get; set; }
    public Vaso VasosGrande { get; set; }
    public Azucarero Azucarero { get; set; }

    // Según el tamaño que pida el cliente, devuelve los vasos que le tocan.
    // Si escribe algo que no es "mediano" ni "grande", le da el pequeño.
    public Vaso GetTipoDeVaso(string tipoDeVaso) => tipoDeVaso switch
    {
        "mediano" => VasosMediano,
        "grande" => VasosGrande,
        _ => VasosPequeno
    };

    // Sirve el café. Primero revisa que haya vasos, café y azúcar.
    // Si falta algo, devuelve el mensaje de error y no sirve nada.
    // Si todo está bien, sirve y devuelve "Felicitaciones".
    public string GetVasoDeCafe(Vaso vaso, int cantidadDeVasos, int cantidadDeAzucar)
    {
        // Calculamos cuánto café se necesita (vasos pedidos x lo que lleva cada vaso)
        int cafeNecesario = cantidadDeVasos * vaso.GetContenido();

        // Revisamos que haya de todo
        if (!vaso.HasVasos(cantidadDeVasos))
            return MensajeNoHayVasos;

        if (!Cafetera.HasCafe(cafeNecesario))
            return MensajeNoHayCafe;

        if (!Azucarero.HasAzucar(cantidadDeAzucar))
            return MensajeNoHayAzucar;

        // Si hay de todo, servimos el café
        Servir(vaso, cantidadDeVasos, cafeNecesario, cantidadDeAzucar);

        return MensajeExito;
    }

    // Gasta el café, los vasos y el azúcar que se usaron al servir
    private void Servir(Vaso vaso, int cantidadDeVasos, int cafeNecesario, int cantidadDeAzucar)
    {
        Cafetera.GiveCafe(cafeNecesario);
        vaso.GiveVasos(cantidadDeVasos);
        Azucarero.GiveAzucar(cantidadDeAzucar);
    }
}