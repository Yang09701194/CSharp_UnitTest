using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestPractice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPractice.Tests
{
	[TestClass()]
	public class WaterBottlesTests
	{
		// Menu > Test Explorer   或右鍵新增Test專案  還有左邊三種run和方法上右鍵run
		[TestMethod()]
		[Timeout(2000)]  // Milliseconds
		public void NumWaterBottlesTest()
		{
			// arrange
			int numBottles = 9, numExchange = 3;
			int expected = 13;

			// act
			WaterBottles waterBottles = new WaterBottles();
			int result = waterBottles.NumWaterBottles(numBottles, numExchange);
			
			// assert
			Assert.AreEqual(expected, result);

		}
	}
}