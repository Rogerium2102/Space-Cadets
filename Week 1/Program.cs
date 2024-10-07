using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Week_1
{
    internal class Program
    {
        static string FiltlerResponseGetName(string Body)
        {
            string foundDescription = Body.Substring(Body.IndexOf("description"), Body.IndexOf("link") - Body.IndexOf("description"));
            string UserTitle = ObtainTitle(foundDescription);
            if (UserTitle == "")
            {
                Console.WriteLine("Unable to determine staff title! Formatting may be broken!");
            }
            int beginProfessor = foundDescription.IndexOf(UserTitle);
            int foundIs = foundDescription.IndexOf(" is ");
            string foundName = foundDescription.Substring(beginProfessor, foundIs - beginProfessor);
            return foundName;
        }

        static string ObtainTitle(string Body)
        {
            string[] Titles = new string[] {"Professor", "Doctor","Dr","Ms","Mrs","Mr","Master","Miss", "Emeritus Professor" };
            int Lowest = 1000000000;
            int CurrentIndex;
            string First = "";
            foreach (string c in Titles)
            {
                CurrentIndex = Body.IndexOf(c);
                if (CurrentIndex != -1)
                {
                    if (CurrentIndex < Lowest)
                    {
                        Lowest = CurrentIndex;
                        First = c;
                    }
                }
            }
            return First; 
        }

        static string RequestResponse = "";
        static async void GetRequestResponse(string User)
        {
            HttpClient client = new HttpClient();
            using (HttpResponseMessage response = await client.GetAsync("https://www.southampton.ac.uk/people/"+ User))
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                RequestResponse = responseBody;
                Console.WriteLine(FiltlerResponseGetName(RequestResponse));
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input email ID:");
            string ID = Console.ReadLine();
            GetRequestResponse(ID);
            Console.ReadLine();
        }
    }
}
