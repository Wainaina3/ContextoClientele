using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Contexto
{
    class EmailContext
    {
       Outlook.Application myApp = new Microsoft.Office.Interop.Outlook.Application();
        //define class public variables
        string contextCategory;


        //declare methods in this class
        public Boolean checkContext()
        {
            return false;
        }
        public void addMailToContextCategory() {

        }
        public Boolean removeMailFromContextCategory()
        {
            return false;
        }
        public void getNewEmail()
        {

        }
        public void muteNotifications()
        {

        }
        public void createContextCategory()
        {
            //delete later. Just for test
            contextCategory = "project";

            Outlook.Categories categories =
      myApp.Session.Categories;
            if (!CategoryExists(getContextCategory()))
            {
                Outlook.Category category = categories.Add(getContextCategory(),
                    Outlook.OlCategoryColor.olCategoryColorDarkBlue,
                    Outlook.OlCategoryShortcutKey.olCategoryShortcutKeyCtrlF11);
            }
        }
        public string getContextCategory()
        {

            return contextCategory;
        }
        /*
        *This function deletes a category from the mail client
        */
        public void deleteContextCategory(string categoryName)
        {

        }

        private bool CategoryExists(string categoryName)
        {
            try
            {
                Outlook.Category category =
                    myApp.Session.Categories[categoryName];
                if(category != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch {
                return false;
            }
          }

        }
}
