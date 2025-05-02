using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptions.Excepciones;

namespace Dsw2025Ej8.Domain;

public class CuentaDeAhorro : CuentaBancaria
{
    public CuentaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {

    }

    public override void Depositar(decimal monto)
    {

        ValidarOperacion(monto);
        _saldo += monto;
        AplicarInteres();
    }

    public override void Retirar(decimal monto)
    {
        ValidarOperacion(monto);

        if (_saldo - monto < 0)
        {
            _estado = Estado.Suspendida;
            throw new SaldoInsuficienteException();
        }

        _saldo -= monto;
    }

    public void AplicarInteres()
    {
        _saldo += _saldo * _tasaDeInteres;
    }
}
