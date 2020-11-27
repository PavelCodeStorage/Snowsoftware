using System;
using SnowSoftware.Driver;
using SnowSoftware.PageObjectModels;
using Xunit;

namespace SnowSoftware
{
    public class SnowTest
    {
        private SitePage site;
        private Menu menu;
        private SnowGlobe snowGlobe;
        private ReleaseNotes releaseNotes;

        public void Setup()
        {
            WebDriver.CreateDriver();
            site = new SitePage();
            menu = new Menu();
            snowGlobe = new SnowGlobe();
            releaseNotes = new ReleaseNotes();
        }

        [Fact(DisplayName = "Check Exist 'Snow License Manager 9.7.1 Release Note'r")]
        [System.Obsolete] 
        public void CheckReleaseNotes()
        {
            Setup();

            site.NavigateToTheSite("https://www.snowsoftware.com");
            menu.ClickOnSuccessMenu()
                .ClickSnowGlobeCommunity();

            snowGlobe.InputSearchField("Snow License Manager")
                     .ClickReleaseNotes();

            String expectedTitle = "Release Notes: Snow License Manager 9.7.1";

            String expectedNumber = "000013119";

            Assert.Equal(releaseNotes.getTitleText(), expectedTitle);
            Assert.Equal(releaseNotes.getArticleNumber(), expectedNumber);

            After();
        }

        public void After()
        {
            WebDriver.QuitDriver();
        }

    }
}
