using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CuentaDeAhorro : CuentaBancaria
{

    public CuentaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    
    }

    public override void Retirar(decimal monto)
    {

        ValidarOperacion(monto);

        

        if (GetSaldo() - monto < 0)
        {
            SetEstado(Estado.Suspendida);
            throw new ArgumentException("La cuenta no esta activa");
        }

        SetSaldo(GetSaldo() - monto);  
    }
}
