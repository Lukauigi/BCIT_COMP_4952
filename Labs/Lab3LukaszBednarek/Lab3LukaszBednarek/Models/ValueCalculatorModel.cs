using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Data model of the web app.
/// Author: Lukasz Bednarek
/// Date: September 24, 2022
/// </summary>
namespace Lab3LukaszBednarek.Models
{
    /// <summary>
    /// Data model representing the Value Calculator.
    /// </summary>
    public class ValueCalculatorModel
    {
        [Required (ErrorMessage = "Enter a monthly investment.")]
        [Range (1.0, 1000, ErrorMessage = "Possible values: $1-$1000")]
        public decimal? monthlyInvestment { get; set; }
        [Required(ErrorMessage = "Enter a the interest rate.")]
        [Range(.1, 20, ErrorMessage = "Possible values: .1%-20%")]
        public decimal? yearlyInterestRate { get; set; }
        [Required(ErrorMessage = "Enter a the number of years.")]
        [Range(1, 50, ErrorMessage = "Possible values: 1-50")]
        public int? numberOfYears { get; set; }
        
        /// <summary>
        /// Calculates the compounded interest accrued over a time period.
        /// </summary>
        /// <returns> A sum of money accrued.  </returns>
        public decimal? CalculateValue()
        {
            int? numberOfMonths = numberOfYears * 12;
            decimal? monthlyInterestRate = yearlyInterestRate / 12 / 100;
            decimal? result = 0;

            for (int i = 0; i < numberOfMonths; i++)
            {
                result = (result + monthlyInvestment) * (1 + monthlyInterestRate);
            }

            return result;
        }
    }
}
