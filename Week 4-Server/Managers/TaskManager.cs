using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Server.Managers
{
    public class TaskManager
    {
        public TaskManager() 
        {

        }

        public async Task WaitUntil(Func<bool> Condition, int Frequency = 25, int Timeout = -1)
        {
            var WaitTask = Task.Run(async () =>
            {
                while (Condition()) await Task.Delay(Frequency);
            });
            if (WaitTask != await Task.WhenAny(WaitTask, Task.Delay(Timeout)))
            {
                throw new TimeoutException();
            }
        }
        // Copied From STACKOVERFLOW post by Sinaesthetic https://stackoverflow.com/questions/29089417/c-sharp-wait-until-condition-is-true
    }
}
