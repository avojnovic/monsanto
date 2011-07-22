using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Utils
{
   public class ActDirCheck
   {


        public static bool CheckUserAuthentication(String userAccount)
        {
            string domain = "SRVVS2010";
            String account = userAccount.Replace(@"SRVVS2010\", "");
            string group = "Administradores";

            System.DirectoryServices.DirectoryEntry entry = GetDirectoryEntry("/" + GetLDAPDomain(domain), domain);

            try
            { 

                System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + account + ")";
                search.PropertiesToLoad.Add("memberOf");
                System.DirectoryServices.SearchResult result = search.FindOne();

                System.DirectoryServices.DirectorySearcher groupSearch = new System.DirectoryServices.DirectorySearcher(entry);
                groupSearch.Filter = "(SAMAccountName=" + group + ")";
                groupSearch.PropertiesToLoad.Add("member");
                System.DirectoryServices.SearchResult groupResult = groupSearch.FindOne();
                if (result != null)
                {
                    int allGroupCount = result.Properties["memberOf"].Count;

                    int checkGroupCount = groupResult.Properties["member"].Count;

                    for (int i = 0; i < allGroupCount; i++)
                    {
                        string number = result.Properties["memberOf"][i].ToString();
                        for (int j = 0; j < checkGroupCount; j++)
                        {
                            if (number == groupResult.Properties["member"][j].ToString())
                            {

                                return true;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string debug = ex.Message;

                return false;
            }
            return false;
        }


        public static System.DirectoryServices.DirectoryEntry GetDirectoryEntry(string DomainReference, string domain)
        {
            string ADFullPath = "LDAP://" + domain;
            System.DirectoryServices.DirectoryEntry de = new System.DirectoryServices.DirectoryEntry(ADFullPath + DomainReference, "Administrador", "123456", System.DirectoryServices.AuthenticationTypes.Secure);
            return de;
        }

        private static string GetLDAPDomain(string domain)
        {
            StringBuilder LDAPDomain = new StringBuilder();
            string[] LDAPDC = domain.Split('.');
            for (int i = 0; i < LDAPDC.GetUpperBound(0) + 1; i++)
            {
                LDAPDomain.Append("DC=" + LDAPDC[i]);
                if (i < LDAPDC.GetUpperBound(0))
                {
                    LDAPDomain.Append(",");
                }
            }
            return LDAPDomain.ToString();
        }
    }
}
