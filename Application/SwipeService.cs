using Domain.Entities;
using Infrastructure.DAL.Repositories;
using SynConnectDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Application
{
    public class SwipeService : ISwipeService
    {
        SwipeRepository swipeRepo = new SwipeRepository();
        Semaphore semaphore = new Semaphore(3, 3);

        public void AddSwipesToDatabase(Terminal terminal)
        {
            terminal.Status = "Waiting";
            
            semaphore.WaitOne();
            
            terminal.Status = "InProcess";


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
            swipeRepo.BulkInsert(swipes);

            Thread.Sleep(1000);

            semaphore.Release();

            terminal.Status = "Finished";
        }

        private string[] RetriveSwipesData(string IpAddress)
        {
            var swipes = SynConnection.GetInstance();
            var data = swipes.RetrieveSwipes(IpAddress);
            var swipesData = data.Split(new string[] { "\n", "," },
                                        StringSplitOptions.RemoveEmptyEntries);
            return swipesData;
        }

        private string[] RetrieveStudentIds(string[] swipesData)
        {
            return swipesData.Where((x, i) => i % 3 == 0).ToArray();
        }

        private DateTime[] RetrieveTimeEvents(string[] swipesData)
        {
            return swipesData.Where((x, i) => (i + 2) % 3 == 0)
                                .Select(x => DateTime.Parse(x)).ToArray();
        }

        private string[] RetrieveDirections(string[] swipesData)
        {
            return swipesData.Where((x, i) => (i + 1) % 3 == 0).ToArray();
        }
    }
}
