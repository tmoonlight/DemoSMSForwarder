using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSServer.EFRepo
{
    public class SMSRepository
    {
        public void GetSMSList(string userCode, DateTime EndTime)
        {
            using (var dbcontext = new SMSDbContext())
            {
                // dbcontext.SMS.Select()

                //var smsList = from sm in dbcontext.SMS
                //              where sm.SendTime > EndTime
                //              select sm;

                var smslist = dbcontext.SMS
                    .Where(smsObj => smsObj.SendTime > EndTime && smsObj.Sender == userCode)
                    .ToList();
            }
        }

        /// <summary>
        /// 插入短信数量
        /// </summary>
        /// <param name="smsList"></param>
        /// <returns></returns>
        public int AddSmsList(List<SMS> smsList)
        {
            using (var dbcontext = new SMSDbContext())
            {
                dbcontext.AddRange(smsList);
                return dbcontext.SaveChanges();
            }
        }
    }
}
