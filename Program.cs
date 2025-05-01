using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Exceptions.Excepciones;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>();

            var ca1 = new CuentaDeAhorro("CA001", 1000, new[] { "Ana" }) { _tasaDeInteres = 0.02m };
            var ca2 = new CuentaDeAhorro("CA002", 500, new[] { "Luis" }) { _tasaDeInteres = 0.015m };

            var cc1 = new CuentaCorriente("CC001", 1500, new[] { "María" }) { _limiteDeDescubierto = 300 };
            var cc2 = new CuentaCorriente("CC002", 200, new[] { "Pedro" }) { _limiteDeDescubierto = 100 };

            cuentas.Add(ca1);
            cuentas.Add(ca2);
            cuentas.Add(cc1);
            cuentas.Add(cc2);

            foreach (var cuenta in cuentas)
            {
                try
                {
                    cuenta.Depositar(200);
                    cuenta.Retirar(300);
                    cuenta.Retirar(2000);
                }
                catch (MontoNoValidoException ex)
                {
                    Console.WriteLine($"[ERROR] Cuenta {cuenta._numero}: {ex.Message}");
                }
                catch (CuentaNoActivaException ex)
                {
                    Console.WriteLine($"[ERROR] Cuenta {cuenta._numero}: {ex.Message}");
                }
                catch (SaldoInsuficienteException ex)
                {
                    Console.WriteLine($"[ERROR] Cuenta {cuenta._numero}: {ex.Message}");
                }
            }

            // Punto 11: Mostrar resumen con clase anónima
            Console.WriteLine("\nResumen de cuentas:");
            var resumenes = cuentas.Select(c => new
            {
                Numero = c._numero,
                Tipo = c.GetType().Name,
                Saldo = c._saldo
            });

            foreach (var r in resumenes)
            {
                Console.WriteLine($"Cuenta: {r.Numero} | Tipo: {r.Tipo} | Saldo: ${r.Saldo:F2}");
            }
        }
    }
}
