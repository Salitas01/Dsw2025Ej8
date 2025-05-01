namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    
    private string _numero;
    private decimal _saldo;
    private Estado _estado;
    private decimal _tasaDeInteres;
    private decimal _limiteDeDescubierto;
    private decimal _comision;
    private string[] _titulares;

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }
    #region Getters/Setters
    public string GetNumero()
    {
        return _numero;
    }

    public decimal GetSaldo()
    {
        return _saldo;
    }

    public void SetSaldo(decimal saldo)
    {
        _saldo = saldo;
    }

    public Estado GetEstado()
    {
        return _estado;
    }

    public void SetEstado(Estado estado)
    {
        _estado = estado;
    }

    public decimal GetTasaDeInteres()
    {
        return _tasaDeInteres;
    }

    public void SetTasaDeInteres(decimal tasaDeInteres)
    {
        _tasaDeInteres = tasaDeInteres;
    }

    public decimal GetLimiteDeDescubierto()
    {
        return _limiteDeDescubierto;
    }

    public void SetLimiteDeDescubierto(decimal limiteDeDescubierto)
    {
        _limiteDeDescubierto = limiteDeDescubierto;
    }

    public decimal GetComision()
    {
        return _comision;
    }

    public void SetComision(decimal comision)
    {
        _comision = comision;
    }

    public string[] GetTitulares()
    {
        return _titulares;
    }
    #endregion

    protected void ValidarOperacion(decimal monto)
    {
        if (monto <= 0)
        {
            throw new ArgumentException("Monto insuficiente");
        }

        if (_estado != Estado.Activa)
        {
            throw new ArgumentException("La cuenta no esta activa");
        }
    }

    public virtual void Depositar(decimal monto)
    {
        ValidarOperacion(monto);
        _saldo += monto;
    }

    public abstract void Retirar(decimal monto);

    /*public void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }*/
}
