using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Exceptions.Excepciones;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{
    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    }

    public override void Retirar(decimal monto)
    {
        ValidarOperacion(monto);

        if (_saldo - monto < _limiteDeDescubierto)
        {
            _estado = Estado.Suspendida;
            throw new SaldoInsuficienteException();
        }

        _saldo -= monto;
    }

}
