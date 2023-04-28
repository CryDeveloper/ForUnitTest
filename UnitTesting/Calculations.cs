using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UnitTesting
{
    public class Calculations
    {
        /// <summary>
        /// Получение списка свободного времени для консультаций
        /// </summary>
        /// <param name="startTimes">Время начала занятых консультаций</param>
        /// <param name="durations">Время занятых консцультаций</param>
        /// <param name="beginWorkingTime">Начала рабочего дня</param>
        /// <param name="endWorkingTime">Конец рабочего дня</param>
        /// <param name="consultationTime">Стандартное время консультаций</param>
        /// <returns>Массив строк с временем свободных консультаций</returns>
        public static string[] AvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            TimeSpan[] listIntervalWorkingTime = new TimeSpan[] { beginWorkingTime };
            int countBusyTime = 0;
            if (startTimes[0] == beginWorkingTime)
            {
                listIntervalWorkingTime[0] = startTimes[0] + TimeSpan.FromMinutes(durations[0]);
                countBusyTime++;
            }
            for (int i = 0; listIntervalWorkingTime[i] < endWorkingTime; i++)
            {
                Array.Resize(ref listIntervalWorkingTime, i + 2);
                listIntervalWorkingTime[i + 1] = listIntervalWorkingTime[i] + TimeSpan.FromMinutes(30);
                if (listIntervalWorkingTime[i + 1] >= endWorkingTime)
                {
                    Array.Resize(ref listIntervalWorkingTime, listIntervalWorkingTime.Length - 1);
                    break;
                }
                if(countBusyTime < startTimes.Length)
                {
                    while (listIntervalWorkingTime[i] <= startTimes[countBusyTime] && startTimes[countBusyTime] <= listIntervalWorkingTime[i + 1])
                    {
                        listIntervalWorkingTime[i + 1] = startTimes[countBusyTime] + TimeSpan.FromMinutes(durations[countBusyTime]);
                        countBusyTime++;
                        if (countBusyTime >= startTimes.Length)
                        {
                            break;
                        }
                    }
                    while (startTimes[countBusyTime] - listIntervalWorkingTime[i + 1] < TimeSpan.FromMinutes(consultationTime) && startTimes[countBusyTime] - listIntervalWorkingTime[i + 1] != TimeSpan.FromMinutes(0))
                    {
                        listIntervalWorkingTime[i + 1] = startTimes[countBusyTime] + TimeSpan.FromMinutes(durations[countBusyTime]);
                        countBusyTime++;
                        if (countBusyTime >= startTimes.Length)
                        {
                            break;
                        }
                    }
                }
            }
            
            string[] availablePeriods = new string[listIntervalWorkingTime.Length];
            for (int i = 0; i < availablePeriods.Length; i++)
            {
                availablePeriods[i] = listIntervalWorkingTime[i].ToString("hh\\:mm") + "-";
                availablePeriods[i] += (listIntervalWorkingTime[i] + TimeSpan.FromMinutes(30)).ToString("hh\\:mm");
            }
            return availablePeriods;
        }
    }
}
