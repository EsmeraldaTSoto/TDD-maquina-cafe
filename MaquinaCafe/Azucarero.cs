namespace MaquinaCafe;

// Esta clase es el azucarero: guarda cuánta azúcar queda.
public class Azucarero
{
    // Cantidad de azúcar que queda
    private int cantidadAzucar;

    // Al crear el azucarero le decimos con cuánta azúcar empieza
    public Azucarero(int cantidadAzucar)
    {
        this.cantidadAzucar = cantidadAzucar;
    }

    // Revisa si hay suficiente azúcar. Devuelve true si alcanza y false si no.
    public bool HasAzucar(int cantidadSolicitada) =>
        cantidadAzucar >= cantidadSolicitada;

    // Quita azúcar del azucarero cuando se sirve un café
    public void GiveAzucar(int cantidadSolicitada)
    {
        cantidadAzucar -= cantidadSolicitada;
    }

    // Dice cuánta azúcar queda
    public int GetCantidadAzucar() => cantidadAzucar;
}