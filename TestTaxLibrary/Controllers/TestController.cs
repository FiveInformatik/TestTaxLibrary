using Microsoft.AspNetCore.Mvc;
using TaxWareLib;
using TaxWareLib.Interface;

namespace TestTaxLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        
        [HttpGet(Name = "GetTaxes")]
        public decimal Taxes()
        {
            var taxIncomeParams = new TaxesIncomeParams
            {
                Year = 2022,
                ShortnameCanton = "BE",
                NameMunicipality = "Bern",
                Tariff = EnmTariffIncomeAssets.Normal,
                TaxableIncomeCanton = 100_000,
                RatedefIncomeCanton = 100_000
            };

            var taxes = TaxWareLib.TaxCalculator.Default.TaxesIncome(taxIncomeParams);

            return taxes.TaxTotal;
        }
    }
}