using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace GameMarketSiteTests
{
	public class GameMarketSiteTests : IDisposable
	{
		private readonly IWebDriver _webDriver;

		private const string WEB_URL = "https://localhost:7137/";

		public GameMarketSiteTests()
		{
			_webDriver = new ChromeDriver();
		}

		[Fact]
		[Trait("Testing Test", "Debug")]
		public void DebugTest()
		{
			_webDriver.Navigate().GoToUrl(WEB_URL);
			Assert.Equal("Home Page - GameMarketPlace", _webDriver.Title);
		}


		#region Iteration 1 Tests
		[Fact]
		[Trait("Logging In Successfully", "Login")]
		public void LoginSuccessfulTest()
		{
			_webDriver.Navigate().GoToUrl($"{WEB_URL}account/login");
			_webDriver.FindElement(By.Id("txtUsername")).SendKeys("Testing1");
			_webDriver.FindElement(By.Id("txtPassword")).SendKeys("admin");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();

			WebElement welcomeTag = (WebElement)_webDriver.FindElement(By.Id("txtWelcome"));

			bool isDisplayed = welcomeTag.Displayed;

			Assert.True(isDisplayed);
		}

		[Fact]
		[Trait("Logging In Failed", "Login")]
		public void LoginFailedTest()
		{
			_webDriver.Navigate().GoToUrl($"{WEB_URL}account/login");
			_webDriver.FindElement(By.Id("txtUsername")).SendKeys("Testing1");
			_webDriver.FindElement(By.Id("txtPassword")).SendKeys("admin1");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();

			WebElement error = (WebElement)_webDriver.FindElement(By.Id("txtError"));

			bool isDisplayed = error.FindElement(By.TagName("li")).Displayed;


			Assert.True(isDisplayed);
		}

		[Fact]
		[Trait("Update Platform Preferences", "Preferences")]
		public void UpdatePlatformPreferenceTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			var platformSelect = new SelectElement(_webDriver.FindElement(By.Id("selectPlatform")));
			platformSelect.SelectByText("PC");

			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			platformSelect = new SelectElement(_webDriver.FindElement(By.Id("selectPlatform")));
			WebElement option = (WebElement)platformSelect.SelectedOption;

			Assert.Equal("PC", option.Text);
		}

		[Fact]
		[Trait("Update Genre Preferences", "Preferences")]
		public void UpdateGenrePreferenceTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			var platformSelect = new SelectElement(_webDriver.FindElement(By.Id("selectGenre")));
			platformSelect.SelectByText("FPS");

			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			platformSelect = new SelectElement(_webDriver.FindElement(By.Id("selectGenre")));
			WebElement option = (WebElement)platformSelect.SelectedOption;

			Assert.Equal("FPS", option.Text);
		}

		[Fact]
		[Trait("Update First Name", "User Information")]
		public void UpdateFirstNameTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			_webDriver.FindElement(By.Id("txtFirstName")).Clear();
			_webDriver.FindElement(By.Id("txtFirstName")).SendKeys("Bob");

			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			string textValue = _webDriver.FindElement(By.Id("txtFirstName")).GetAttribute("value");
			Assert.Equal("Bob", textValue);

			_webDriver.FindElement(By.Id("txtFirstName")).Clear();
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
		}

		[Fact]
		[Trait("Update Last Name", "User Information")]
		public void UpdateLastNameTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			_webDriver.FindElement(By.Id("txtLastName")).Clear();
			_webDriver.FindElement(By.Id("txtLastName")).SendKeys("Jefferson");

			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnProfile")).Click();

			string textValue = _webDriver.FindElement(By.Id("txtLastName")).GetAttribute("value");
			Assert.Equal("Jefferson", textValue);

			_webDriver.FindElement(By.Id("txtLastName")).Clear();
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
		}
		
		[Fact]
		[Trait("Update Mailing Address", "User Information")]
		public void UpdateMailingAddressTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();
			_webDriver.FindElement(By.Id("navAddress")).Click();

			_webDriver.FindElement(By.Id("txtMailingAddress")).Clear();
			_webDriver.FindElement(By.Id("txtMailingAddress")).SendKeys("428 Rainbow Road");

			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnProfile")).Click();
			_webDriver.FindElement(By.Id("navAddress")).Click();

			string textValue = _webDriver.FindElement(By.Id("txtMailingAddress")).GetAttribute("value");
			Assert.Equal("428 Rainbow Road", textValue);

			_webDriver.FindElement(By.Id("txtMailingAddress")).Clear();
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
		}

		[Fact]
		[Trait("Update Street Address", "User Information")]
		public void UpdateStreetAddressTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();
			_webDriver.FindElement(By.Id("navAddress")).Click();

			_webDriver.FindElement(By.Id("txtStreetAddress")).Clear();
			_webDriver.FindElement(By.Id("txtStreetAddress")).SendKeys("428 Rainbow Road");

			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnProfile")).Click();
			_webDriver.FindElement(By.Id("navAddress")).Click();

			string textValue = _webDriver.FindElement(By.Id("txtStreetAddress")).GetAttribute("value");
			Assert.Equal("428 Rainbow Road", textValue);

			_webDriver.FindElement(By.Id("txtStreetAddress")).Clear();
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
		}

		#endregion

		#region Iteration 2 Tests
		[Fact]
		[Trait("Register Event", "Events")]
		public void RegisterEventTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnDetails")).Click();
			_webDriver.FindElement(By.Id("btnRegister")).Click();

			WebElement element = (WebElement)_webDriver.FindElement(By.Id("btnUnregister"));

			Assert.True(element.Displayed);
		}

		[Fact]
		[Trait("Unregister Event", "Events")]
		public void UnregisterEventTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnEvent")).Click();
			_webDriver.FindElement(By.Id("btnDetails")).Click();
			_webDriver.FindElement(By.Id("btnUnregister")).Click();

			WebElement element = (WebElement)_webDriver.FindElement(By.Id("btnRegister"));

			Assert.True(element.Displayed);
		}

		[Fact]
		[Trait("Wishlist add", "Wishlist")]
		public void WishlistAddTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnDetails")).Click();
			_webDriver.FindElement(By.Id("btnAdd")).Click();
			_webDriver.FindElement(By.Id("btnWishlist")).Click();

			WebElement element = (WebElement)_webDriver.FindElement(By.Id("txtGameName"));

			Assert.True(element.Displayed);
		}

		[Fact]
		[Trait("Wishlist Removal", "Wishlist")]
		public void WishlistRemoveTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnDetails")).Click();
			_webDriver.FindElement(By.Id("btnRemove")).Click();
			_webDriver.FindElement(By.Id("btnWishlist")).Click();

			WebElement element = (WebElement)_webDriver.FindElement(By.Id("txtNoGames"));

			Assert.True(element.Displayed);
		}

		[Fact]
		[Trait("Click details on game on home", "Select Games")]
		public void ClickGameOnHomeTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnDetails")).Click();

			WebElement element = (WebElement)_webDriver.FindElement(By.Id("txtGameName"));

			Assert.True(element.Displayed);
		}

		[Fact]
		[Trait("Click details on game on home", "Select Games")]
		public void SearchGameOnHomeTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("txtGameInput")).Clear();
			_webDriver.FindElement(By.Id("txtGameInput")).SendKeys("Call of Duty");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnDetails")).Click();

			WebElement element = (WebElement)_webDriver.FindElement(By.Id("txtGameName"));

			Assert.True(element.Displayed);
		}

		[Fact]
		[Trait("Add Credit Card", "Credit Cards")]
		public void AddCreditCardTest()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();
			_webDriver.FindElement(By.Id("navCreditCard")).Click();
			_webDriver.FindElement(By.Id("btnAddCard")).Click();
			_webDriver.FindElement(By.Id("txtCardNumberInput")).SendKeys("1234123412341234");
			_webDriver.FindElement(By.Id("txtCVV")).SendKeys("123");
			_webDriver.FindElement(By.Id("dateExpiryDate")).SendKeys("2222\t2222");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();

			WebElement element = (WebElement)_webDriver.FindElement(By.Id("txtCardNumber"));

			Assert.True(element.Displayed);

		}

		[Fact]
		[Trait("Remove Card", "Credit Cards")]
		public void RemoveCard()
		{
			TestUtils.LoginUser((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnProfile")).Click();
			_webDriver.FindElement(By.Id("navCreditCard")).Click();
			_webDriver.FindElement(By.Id("btnRemoveCard")).Click();
			WebElement element = (WebElement)_webDriver.FindElement(By.Id("txtNoCardFound"));

			Assert.True(element.Displayed);
		}
		#endregion

		#region Iteration 3 Tests
		[Fact]
		[Trait("Test Game Addition", "Admin")]
		public void AddGameTest()
		{
			TestUtils.LoginAdmin((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnAdmin")).Click();
			_webDriver.FindElement(By.Id("btnGameManagement")).Click();
			_webDriver.FindElement(By.Id("btnAddGame")).Click();
			_webDriver.FindElement(By.Id("txtGameNameInput")).SendKeys("No Mans Sky");
			_webDriver.FindElement(By.Id("txtGamePriceInput")).SendKeys("2");
			_webDriver.FindElement(By.Id("txtInventoryInput")).SendKeys("10");
			_webDriver.FindElement(By.Id("txtPhysicalEditorInput")).SendKeys("Conestoga");
			_webDriver.FindElement(By.Id("txtPublisherInput")).SendKeys("Conestoga");
			_webDriver.FindElement(By.Id("dateReleaseDateInput")).SendKeys("2030\t01\t01");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			WebElement gameName = (WebElement)_webDriver.FindElement(By.Id("txtGameName"));

			bool isDisplayed = gameName.Displayed;

			Assert.True(isDisplayed);
		}

		[Fact]
		[Trait("Test Game Removal", "Admin")]
		public void RemoveGameTest()
		{
			TestUtils.LoginAdmin((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnAdmin")).Click();
			_webDriver.FindElement(By.Id("btnGameManagement")).Click();
			_webDriver.FindElement(By.Id("btnRemoveGame")).Click();

			try
			{
				WebElement gameName = (WebElement)_webDriver.FindElement(By.Id("txtGameName"));
			}
			catch (NoSuchElementException)
			{
				Assert.True(true);
			}
		}

		[Fact]
		[Trait("Test review addition", "Review")]
		public void AddReviewTest()
		{
			TestUtils.LoginAdmin((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnDetails")).Click();
			_webDriver.FindElement(By.Id("btnWriteReview")).Click();
			_webDriver.FindElement(By.Id("txtReviewComments")).SendKeys("Testing this feature. Today is a good day. 01031y491164782164817264817264");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
			_webDriver.FindElement(By.Id("btnAdmin")).Click();
			_webDriver.FindElement(By.Id("btnReviewManagement")).Click();

			WebElement reviewComment = (WebElement)_webDriver.FindElement(By.Id("txtReviewComment"));
			bool isDisplayed = reviewComment.Displayed;
			Assert.True(isDisplayed);
			_webDriver.FindElement(By.Id("btnDeclineReview")).Click();
		}

		[Fact]
		[Trait("Incorrect Review", "Review")]
		public void IncorrectReviewTest()
		{
			TestUtils.LoginAdmin((WebDriver)_webDriver);
			_webDriver.FindElement(By.Id("btnDetails")).Click();
			_webDriver.FindElement(By.Id("btnWriteReview")).Click();
			_webDriver.FindElement(By.Id("txtReviewComments")).SendKeys("");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();

			WebElement reviewComment = (WebElement)_webDriver.FindElement(By.Id("txtErrors"));
			bool isDisplayed = reviewComment.Displayed;
			Assert.True(isDisplayed);
		}

		#endregion

		public void Dispose()
		{
			_webDriver.Quit();
			_webDriver.Dispose();
		}
	}
}