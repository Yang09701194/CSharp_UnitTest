using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPractice
{
	public class WaterBottles
	{

		// mouse right click > top create unit tests
		public int NumWaterBottles(int numBottles, int numExchange)
		{
			int totalDrinkBottles = numBottles;
			return Drink(totalDrinkBottles, totalDrinkBottles, numExchange);
		}

		private int Drink(int totalDrinkBottles, int emptyBottles, int numExchange)
		{
			int exchangeRemainEmpty = emptyBottles % numExchange;
			int exchange = emptyBottles / numExchange;
			if (exchange == 0)
				return totalDrinkBottles;

			emptyBottles = exchangeRemainEmpty + exchange;
			totalDrinkBottles += exchange;

			return Drink(totalDrinkBottles, emptyBottles, numExchange);
		}

	}
}
