using static Dsw2025Ej8.Domain.Exceptions.Excepciones;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{

    public string _numero { get; }
    public decimal _saldo { get; protected set; }
    public Estado _estado { get; protected set; }
    public string[] _titulares { get; }
    public decimal _tasaDeInteres { get; set; }
    public decimal _limiteDeDescubierto { get;  set; }
    public decimal _comision { get; protected set; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }

    protected void ValidarOperacion(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValidoException();
        }

        if (_estado != Estado.Activa)
        {
            throw new CuentaNoActivaException(_estado.ToString());
        }
    }

    public abstract void Depositar(decimal monto);
   

    public abstract void Retirar(decimal monto);

}
