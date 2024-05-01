using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using OpenDialogWindowHandler;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DotNetSelenium
{
    /*  Total TestCases : 44
     *  successfully Run : 13 +11=23
     *  revisit Tc's : 3+1=4
     *  Selectors Used : CssSelector,Xpath,Id,Linktext
     *  wait allowed : 5000 seconds
     *  URL used : https://the-internet.herokuapp.com/
     *  Language : C#
     *  Framework : NUNIT, .Net
     *  Versions: Selenium - 4.20.0
     *            NUNIT - 3.13.3
     *            .Net - 8.0
     *            C# - 12.0
     *  
     */
    public class BasicElementInteraction
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            driver.Manage().Window.Maximize();
        }
     

        [Test]
        public void A_B_Testing() 
        {           
             driver.FindElement(By.LinkText("A/B Testing")).Click();                       
        }

        [Test]
        public void Add_Remove_Elements() 
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[2]/a")).Click();
            driver.FindElement(By.XPath("//button[@onclick='addElement()']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@onclick='deleteElement()']")).Click();
            Thread.Sleep(1000);

        }

        [Test] //worked on later 
        [TestCategory("Authentication")]
        public void Basic_Auth() 
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[3]/a")).Click();
        }
        [Test]
        public void Broken_Image()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[4]/a")).Click();
        }
        [Test]
        public void Challengeing_DOM()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[5]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("button")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("alert")).Click();
           // driver.FindElement(By.ClassName(" button alert")).Click();     compund classnames not allowed
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("success")).Click();
            Thread.Sleep(2000);
        }

        [Test]
        public void CheckBoxes()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[6]/a")).Click();
            driver.FindElement(By.XPath("//input[@type='checkbox'][1]")).Click();
            driver.FindElement(By.XPath("//input[@type='checkbox'][2]")).Click();
            Thread.Sleep(2000);
        }

        [Test]  // worked on later
        public void Context_Menu()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[7]/a")).Click();
        }

        [Test] // worked on later
        [TestCategory("Authentication")]
        public void Digest_Authentication()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[8]/a")).Click();
        }

        [Test]
        public void Disappraring_Element()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[9]/a")).Click();
            Thread.Sleep(5000);
            //Home

            driver.FindElement(By.LinkText("Home")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[9]/a")).Click();
            Thread.Sleep(5000);
/*
            //About
            
                driver.FindElement(By.LinkText("About")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[9]/a")).Click();
                Thread.Sleep(5000);

            
            
            //Contact Us

            driver.FindElement(By.LinkText("Contact Us")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[9]/a")).Click();
            Thread.Sleep(5000);

            //Portfolio
            driver.FindElement(By.LinkText("Portfolio")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[9]/a")).Click();
            Thread.Sleep(5000);

            //Gallery
            driver.FindElement(By.LinkText("Gallery")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[9]/a")).Click();
            Thread.Sleep(5000);
*/

        }

        [Test]
        public void Drag_And_Drop()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[10]/a")).Click();

            var element1 = driver.FindElement(By.Id("column-a"));
            var element2 = driver.FindElement(By.Id("column-b"));

           Actions builder =  new Actions(driver);
             IAction dragAndDrop1 = builder.ClickAndHold(element2).MoveToElement(element1).Release(element1).Build();
             dragAndDrop1.Perform();
            Thread.Sleep(5000);

            

            
        }

        [Test]
        public void Dropdown()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[11]/a")).Click();
            //select the dropdown
            driver.FindElement(By.Id("dropdown")).Click();
            //Slect the the Option1
            driver.FindElement(By.XPath("//option[@value=1]")).Click();
            Thread.Sleep(5000);
            //Again select dropdown
            driver.FindElement(By.Id("dropdown")).Click();
            // Select Option2
            driver.FindElement(By.XPath("//option[@value=2]")).Click();
            Thread.Sleep(5000);

        }

        [Test]
        public void Dynamic_Content()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[12]/a")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("click here")).Click();
            Thread.Sleep(5000);

        }

        [Test]
        public void Dynamic_Controls()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[13]/a")).Click();
            //slect checbox
            driver.FindElement(By.CssSelector("input[type='checkbox']")).Click();
            //Click Remove
            driver.FindElement(By.XPath("//*[@id=\"checkbox-example\"]/button")).Click();
            Thread.Sleep(5000);
            String msg1 = driver.FindElement(By.Id("message")).Text;
            Console.WriteLine(msg1);



            //click Enable
            driver.FindElement(By.XPath("//*[@id=\"input-example\"]/button")).Click();
            Thread.Sleep(5000);
            //type in place holder
            driver.FindElement(By.CssSelector("input[type=text]")).SendKeys("Enabled");

            String msg2 = driver.FindElement(By.Id("message")).Text;
            Console.WriteLine(msg2);

            Thread.Sleep(5000);
            
            //Click remove button
        }
        [Test]
        public void Dynamic_Loading()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[14]/a")).Click();
            driver.FindElement(By.LinkText("Example 1: Element on page that is hidden")).Click();
            driver.FindElement(By.XPath("//*[@id='start']/button")).Click();
            Thread.Sleep(5000);
            String Msg1=driver.FindElement(By.Id("finish")).Text;
            Console.WriteLine(Msg1);
            Thread.Sleep(5000) ;
            driver.Navigate().Back();

            //Example 2: Element rendered after the fact
            driver.FindElement(By.LinkText("Example 2: Element rendered after the fact")).Click();
            driver.FindElement(By.XPath("//*[@id='start']/button")).Click();
            Thread.Sleep(5000);
            String Msg2 = driver.FindElement(By.Id("finish")).Text;
            Console.WriteLine(Msg2);
        }

        [Test]
        public void EntryAD()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[15]/a")).Click();
            driver.FindElement(By.CssSelector("div[class='modal']"));                      //popup
            Thread.Sleep(5000);
            String Text= driver.FindElement(By.XPath(" //*[@id=\"modal\"]/div[2]/div[2]/p")).Text;   //popup text
            
            driver.FindElement(By.XPath("//*[@id=\"modal\"]/div[2]/div[3]/p")).Click();   // click close popup
            Console.WriteLine(Text);
        }

        [Test] //passed; but need to work
        public void ExitIntent()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[16]/a")).Click();
            String ExitIntent = driver.FindElement(By.XPath("//div[@class='example']/p")).Text;
            Console.WriteLine(ExitIntent);
        }

        [Test]
        [TestCategory("File")]
        public void FileDownLoad()
        {
            /*
        * file to Download : fileToUpload.txt
        *              some-file.txt
        *              create-function-python.png
        *              random_data.txt
        *              snickers2.jpg
        *              renamed_file.pdf
        *              github.png
        */
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[17]/a")).Click();
            driver.FindElement(By.LinkText("fileToUpload.txt")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("some-file.txt")).Click();
            Thread.Sleep(2000); 
            driver.FindElement(By.LinkText("create-function-python.png")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("random_data.txt")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("snickers2.jpg")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("renamed_file.pdf")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("github.png")).Click();
            Thread.Sleep(2000);
        }

        [Test]  //tricky tc
        [TestCategory("File")]
        public void FileUpload()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[18]/a")).Click();
            //driver.FindElement(By.CssSelector("input[id='file-upload']")).Click(); 
            Thread.Sleep(5000);
            driver.FindElement(By.Id("file-upload")).SendKeys("C:\\Users\\small\\Downloads\\fileToUpload.txt");
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("input[id=\"file-submit\"]")).Click();
            Thread.Sleep(2000);
            String Uploadfile = driver.FindElement(By.CssSelector("div[id=uploaded-files]")).Text;
            Console.WriteLine(Uploadfile);
            
          
        }

        [Test]
        public void FloatingMenu()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[19]/a")).Click();
            driver.FindElement(By.LinkText("Home")).SendKeys(Keys.PageDown);
            Thread.Sleep(5000);
           
        }

        [Test]
        public void ForgotPassword()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[20]/a")).Click();
            driver.FindElement(By.CssSelector("input[type=text]")).SendKeys("dummy@gmail.com");
            driver.FindElement(By.ClassName("icon-2x")).Click();
            Thread.Sleep(2000);
            String Pass =driver.FindElement(By.XPath("//h1")).Text;
            Console.WriteLine(Pass);

        }

        [Test]
        [TestCategory("Authentication")]
        public void Form_Authentication()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[21]/a")).Click();
            //username
            driver.FindElement(By.CssSelector("input[id=username]")).SendKeys("tomsmith");
            //password
            driver.FindElement(By.CssSelector("input[id=password]")).SendKeys("SuperSecretPassword!");
            //click Login Button
            driver.FindElement(By.ClassName("fa-sign-in")).Click() ;
            //print msg
            String SecureMsg = driver.FindElement(By.ClassName("success")).Text ;
            Console.WriteLine(SecureMsg);

            Thread.Sleep (1000);

            //click Logout
            driver.FindElement(By.ClassName("button")).Click();

        }

        [Test]  //partial passing
        [TestCategory("Frames")]
        public void Frames()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[22]/a")).Click();

            //Nested frames
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[1]/a")).Click();
            driver.Navigate().Back();

            //iframe
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[2]/a")).Click();
            Thread.Sleep(5000) ;
            driver.SwitchTo().DefaultContent();//driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div")));
            driver.FindElement(By.XPath("//*[@id=\"tinymce\"]/p")).SendKeys("iframes page");
        }

        [Test]
        public void Geolocation()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[23]/a")).Click();
            driver.FindElement(By.TagName("button")).Click ();
            Thread.Sleep(5000);
            driver.FindElement(By.LinkText("See it on Google")).Click();
            Thread.Sleep(12000);
        }
        [Test]
        public void HorizentolSlider()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[24]/a")).Click();
            var slider = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div/input"));
            for (int i = 0; i <= 5; i++)
            {
                slider.SendKeys(Keys.ArrowRight);
            }
            Thread.Sleep(5000);
        }
        [Test]
        public void Hovers()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[25]/a")).Click();
            Thread.Sleep(5000);
           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[1]/img"));

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(2000);
        }

        [Test]   // most typical one....i loved it
        
        public void Infinite_Scroll()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[26]/a")).Click();
            // JavaScript executor to scroll
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

            // Explicit wait
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Determine the initial height of the page
            long initialHeight = (long)jsExecutor.ExecuteScript("return document.body.scrollHeight");

            // Loop until a certain condition (e.g., maximum number of scrolls)
            int maxScrolls = 10; // Adjust based on your need
            int currentScroll = 0;

            while (currentScroll < maxScrolls)
            {
                // Scroll to the bottom
                jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                // Wait for the new content to load
                Thread.Sleep(2000); // Simple delay, you can replace with an explicit wait

                // Check the new height
                long newHeight = (long)jsExecutor.ExecuteScript("return document.body.scrollHeight");

                // If the height hasn't changed, break the loop (no more content to load)
                if (newHeight == initialHeight)
                {
                    break;
                }

                // Update the height for the next iteration
                initialHeight = newHeight;
                currentScroll++;
            }

            Console.WriteLine("Finished scrolling");

        }

        [Test]
        public void Inputs()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[27]/a")).Click();
            driver.FindElement(By.CssSelector("input[type=number]")).SendKeys(Keys.ArrowDown);
            Thread.Sleep(2000);
        }

        [Test]  //intrested one
        public void JQuery_UI_Menu()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[28]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"ui-id-4\"]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"ui-id-7\"]/a")).Click();
            Thread.Sleep(2000);

        }

        [Test]
        [TestCategory("Alerts")]
        [TestCategory("JavaScripts")]
        public void JavaScript_Alerts()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[29]/a")).Click();
            //JS ALErt
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[1]/button")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(5000);
            String AlertSuccesmsg = driver.FindElement(By.XPath("//*[@id=\"result\"]")).Text;
            Console.WriteLine(AlertSuccesmsg);
            //Js Confirm
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[2]/button")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().Accept();
            String Comfirmmsg = driver.FindElement(By.XPath("//*[@id=\"result\"]")).Text;
            Console.WriteLine(Comfirmmsg);
            //js Prompt
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[3]/button")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().SendKeys("JS Peompt");
            driver.SwitchTo().Alert().Accept();
            String promptmsg = driver.FindElement(By.XPath("//*[@id=\"result\"]")).Text;
            Console.WriteLine(promptmsg);
            
        }

        [Test]
        [TestCategory("JavaScripts")]
        public void JavaScript_Onload_Event_Error()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[30]/a")).Click();
           String text= driver.FindElement(By.XPath("/html/body")).Text;
            Console.WriteLine(text);
        }

        [Test]
        public void KeyPresses()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[31]/a")).Click();
            driver.FindElement(By.CssSelector("input[id=target]")).SendKeys(Keys.Backspace);
            String res = driver.FindElement(By.CssSelector("p[id=result]")).Text;
            Console.WriteLine(res);

        }
        [Test]
        public void Large_And_Deep_DOM()
        {
            
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[32]/a")).Click();
             driver.FindElement(By.Id("sibling-2.1"));
             //Console.WriteLine(Num);
            


        }

        [Test]
        public void Multiple_Windows()
        {
             
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[33]/a")).Click();

            // Store the original window handle
            string originalWindow = driver.CurrentWindowHandle;

            // Click the link that opens a new window
            IWebElement link = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/a"));
                link.Click();
            Thread.Sleep(2000);

            // Get all window handles
            List<string> windowHandles = new List<string>(driver.WindowHandles);

            // Find the new window handle and switch to it
            foreach (string window in windowHandles)
            {
                if (window != originalWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            //driver.SwitchTo().Window(window);

            // Perform operations in the new window
            IWebElement newWindowText = driver.FindElement(By.XPath("/html/body/div/h3"));
            Console.WriteLine("Text in new window: " + newWindowText.Text);


            // Close the new window
            driver.Close();

            // Switch back to the original window
            driver.SwitchTo().Window(originalWindow);

            // Perform operations in the original window
            IWebElement header = driver.FindElement(By.TagName("h3"));
            Console.WriteLine("Text in the original window: " + header.Text);



        }

        [Test]
        [TestCategory("Frames")]
        public void Nested_Frames()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[34]/a")).Click();

           
            // Switch to the top frame
            driver.SwitchTo().Frame("frame-top");

            // Switch to the left frame inside the top frame
            driver.SwitchTo().Frame("frame-left");

            // Interact with an element in the left frame (e.g., get text)
            string leftText = driver.FindElement(By.TagName("body")).Text;
            Console.WriteLine($"Left Frame Text: {leftText}");

            // Return to the top frame and then switch to the middle frame
            driver.SwitchTo().ParentFrame(); // back to "frame-top"
            driver.SwitchTo().Frame("frame-middle");

            // Interact with an element in the middle frame
            string middleText = driver.FindElement(By.Id("content")).Text;
            Console.WriteLine($"Middle Frame Text: {middleText}");

            driver.SwitchTo().ParentFrame();
            // Switch to the bottom frame
            driver.SwitchTo().Frame("frame-bottom");
            // html / frameset / frame[2]

            // Interact with an element in the left frame (e.g., get text)
            string bottomText = driver.FindElement(By.TagName("body")).Text;
            Console.WriteLine($"Left Frame Text: {bottomText}");

            // Return to the default content (main document)
            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void Notification_Messages()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[35]/a")).Click();
        }

        [Test]
        public void Redirect_Link()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[36]/a")).Click();
        }

        [Test]
        public void Secure_File_Download()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[37]/a")).Click();
        }

        [Test]
        public void Shadowed_DOM()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[38]/a")).Click();
        }

        [Test]
        public void Shifting_Content()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[39]/a")).Click();
        }

        [Test]
        public void SlowResources()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[40]/a")).Click();
        }

        [Test]
        public void Sortable_DataTables()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[41]/a")).Click();
        }
        [Test]
        public void Status_Codes()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[42]/a")).Click();
        }
        [Test]
        public void Typos()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[43]/a")).Click();
        }
        [Test]
        public void WYSIWYG_Editor()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[44]/a")).Click();
        }
        [TearDown]
        public void Teardown() 
        {
            driver.Close();
        }

    }
}