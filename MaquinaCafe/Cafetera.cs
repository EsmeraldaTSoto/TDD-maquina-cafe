namespace MaquinaCafe;

// Esta clase es la cafetera: guarda cuánto café hay para servir.
public class Cafetera
{
    // Cantidad de café que queda en la cafetera
    private int cantidadCafe;

    // Al crear la cafetera le decimos con cuánto café empieza
    public Cafetera(int cantidadCafe)
    {
        this.cantidadCafe = cantidadCafe;
    }

    // Revisa si hay suficiente café. Devuelve true si alcanza y false si no.
    public bool HasCafe(int cantidadSolicitada) =>
        cantidadCafe >= cantidadSolicitada;

    // Quita café de la cafetera cuando se sirve un vaso
    public void GiveCafe(int cantidadSolicitada)
    {
        cantidadCafe -= cantidadSolicitada;
    }

    // Dice cuánto café queda
    public int GetCantidadCafe() => cantidadCafe;
}