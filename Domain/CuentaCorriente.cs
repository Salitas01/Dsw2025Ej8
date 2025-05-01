using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{
    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    }

    public override void Retirar(decimal monto)
    {
        ValidarOperacion(monto);

        if (GetSaldo() - monto < -GetLimiteDeDescubierto())
        {
            SetEstado(Estado.Suspendida);
            throw new ArgumentException("La cuenta no esta activa");
        }

        SetSaldo(GetSaldo() - monto);
    }

}
