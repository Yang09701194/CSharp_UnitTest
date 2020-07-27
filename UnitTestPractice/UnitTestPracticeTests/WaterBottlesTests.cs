using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestPractice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace UnitTestPractice.Tests
{
	[TestClass()]
	public class WaterBottlesTests
	{
		// Menu > Test Explorer   還有左邊三種run和方法上右鍵run
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


		[TestMethod()]
		[Timeout(20000)]  // Milliseconds
		public void GithubFetcherTest()
		{
			// arrange
			//int numBottles = 9, numExchange = 3;
			string expected = "https://api.github.com/user";

			// act
			GithubFetcher fetcher = new GithubFetcher();
			string resultUrl = fetcher.GetData();


			// assert
			Assert.AreEqual(expected, resultUrl);

		}




		/// <summary>
		/// 我先查UT 查幾篇翻到這篇比較順眼的  沒有細看     然後隔兩天去喝下午茶  剛好講師就講到NSubstitute 再回來看這篇  就剛好是提到NSubstitute
		///
		/// 這邊重點中的重點就是  這個套件可以
		///
		///利用介面  隔離開任何需要特殊設定或環境或要求才能運作的動作  可以直接設定回傳值  但是又符合方法的interface規範
		///
		/// 最簡單的例子就是去資料庫查資料的回傳值  一斷線就無法測試
		///
		/// 我這邊用另個類似的例子   是call web api
		///
		/// 實際測試NSubstitude運作成功  用介面的方式讓程式長得好像真的在操作原本的實體物件
		/// 利用Returns 真的就能記住 設定過的回傳值
		///
		/// 官網  https://nsubstitute.github.io/help/getting-started/
		///  
		/// </summary>
		[TestMethod()]
		[Timeout(20000)]  // Milliseconds
		public void GithubFetcherTestMock()
		{
			// arrange
			//int numBottles = 9, numExchange = 3;
			string expected = "https://api.github.com/user";

			// act
			var fetcher = Substitute.For<IFetcher>();
			fetcher.GetData().Returns("https://api.github.com/user");
			string resultUrl = fetcher.GetData();
			// assert
			Assert.AreEqual(expected, resultUrl);

		}





	}
}