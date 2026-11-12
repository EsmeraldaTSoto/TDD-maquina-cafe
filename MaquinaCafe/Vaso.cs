namespace MaquinaCafe;

// Esta clase representa los vasos de un mismo tamaño (pequeño, mediano o grande).
// Guarda cuántos vasos quedan y cuánto café cabe en cada uno.
public class Vaso
{
    // Cuántos vasos quedan disponibles
    private int cantidadVasos;

    // Cuánto café lleva cada vaso de este tamaño
    private int contenido;

    // Al crear los vasos le decimos cuántos hay y cuánto café lleva cada uno
    public Vaso(int cantidadVasos, int contenido)
    {
        this.cantidadVasos = cantidadVasos;
        this.contenido = contenido;
    }

    // Revisa si quedan suficientes vasos. Devuelve true si alcanzan y false si no.
    public bool HasVasos(int cantidadSolicitada) =>
        cantidadVasos >= cantidadSolicitada;

    // Quita vasos del total, por ejemplo cuando se sirve un café
    public void GiveVasos(int cantidadSolicitada)
    {
        cantidadVasos -= cantidadSolicitada;
    }

    // Dice cuántos vasos quedan
    public int GetCantidadVasos() => cantidadVasos;

    // Dice cuánto café lleva cada vaso
    public int GetContenido() => contenido;
}