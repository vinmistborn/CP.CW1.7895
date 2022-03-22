using Domain.Entities;
using Infrastructure.DAL.Repositories;
using SynConnectDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class SwipeService
    {
        /// <summary>
        /// Retrieves Swipes data from the terminal and separates into individual swipe objects
        /// </summary>
        /// <param name="terminal">IP address of swipes</param>
        /// <returns>a list of swipes of a terminal</returns>
        public List<Swipe> RetrieveSwipes(Terminal terminal)
        {
            var swipesData = RetriveSwipesData(terminal.IP);
            var studentIds = RetrieveStudentIds(swipesData);
            var timeEvents = RetrieveTimeEvents(swipesData);
            var directions = RetrieveDirections(swipesData);

            var swipes = new List<Swipe>();
            for (int i = 0; i < studentIds.Length; i++)
            {
                var swipe = new Swipe
                {
                    IpAddress = terminal.IP,
                    StudentId = studentIds[i],
                    EventTime = timeEvents[i],
                    Direction = directions[i]
                };
                swipes.Add(swipe);
            }

            return swipes;
        }

        /// <summary>
        /// Retrieves swipes data from the IP address
        /// </summary>
        /// <param name="IpAddress">IP address that swipes belong to</param>
        /// <returns>an array of swipe data of an IpAddress</returns>
        private string[] RetriveSwipesData(string IpAddress)
        {
            //Getting an instance of third-party library
            var swipes = SynConnection.GetInstance();
            //Retrieving the string of swipes of an IP Address
            var data = swipes.RetrieveSwipes(IpAddress);
            //Splitting the string into an array of strings
            var swipesData = data.Split(new string[] { "\n", "," },
                                        StringSplitOptions.RemoveEmptyEntries);
            return swipesData;
        }

        /*-----Individual *column* separation methods----*/
        
        /// <summary>
        /// Retrieves student ids from given swipes data
        /// </summary>
        /// <param name="swipesData">not filtered swipes data</param>
        /// <returns>an array of student ids</returns>
        private string[] RetrieveStudentIds(string[] swipesData)
        {
            //Getting student ids based on index number in the swipesData array
            //Every element of an index i that is divisible by 3 will be included in the output
            return swipesData.Where((x, i) => i % 3 == 0).ToArray();
        }

        /// <summary>
        /// Retrieves date and time of swipes from given swipes data
        /// </summary>
        /// <param name="swipesData">not filtered swipes data</param>
        /// <returns>an array of data time of time events</returns>
        private DateTime[] RetrieveTimeEvents(string[] swipesData)
        {
            //Getting dateTimes based on index number in the swipesData array
            //And parsing the string in the array into data time object
            return swipesData.Where((x, i) => (i + 2) % 3 == 0)
                                .Select(x => DateTime.Parse(x)).ToArray();
        }

        /// <summary>
        /// Retrieves directions (IN, OUT) from given swipes data
        /// </summary>
        /// <param name="swipesData">not filtered swipes data</param>
        /// <returns>an array of string of directions</returns>
        private string[] RetrieveDirections(string[] swipesData)
        {
            //Getting directions based on index number in the swipesData array
            return swipesData.Where((x, i) => (i + 1) % 3 == 0).ToArray();
        }
    }
}
