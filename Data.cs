using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flex00
{
    static class Data
    {
        public static string Sql { get; set; }
        public static bool DoIt { get; set; }
        public static string Action { get; set; } // Изменить или добавить
        public static string Id { get; set; }

        public static string Surname { get; set; }
        public static string Name { get; set; }
        public static string IdOfClient { get; set; }
        public static string SubscriptionNumber { get; set; }
        public static string SubscriptionType { get; set; }
        public static string StartDate { get; set; }
        public static string EndDate { get; set; }
        public static string Limit { get; set; }
        public static string PaymentDate { get; set; }
        public static string WithTrainer { get; set; }
        public static string Discount { get; set; }
        public static string TypePayment { get; set; }
        public static string Amount { get; set; }
        public static string Phone { get; set; }
        public static string Additional { get; set; }
        
        public static string Type { get; set; }
        public static string Login { get; set; }

        public static List<string> Service    { get; set; }
        public static List<string> SubNumbers { get; set; }
        public static List<string> Discounts  { get; set; }

        public static string SqlEvent { get; set; }
        public static string SqlEventDate { get; set; }
        public static string SqlEventWho { get; set; }
        public static string SqlEventType { get; set; }

        public static List<string> SubTypes { get; set; }

        public static string Month { get; set; } // чтобы хранить кол-во месяцев
        public static string Price { get; set; } // чтобы хранить цену (нужна для расчета со скидкой)

        public static string Archive { get; set; } // чтобы хранить название текущей таблицы архива
    }
}
