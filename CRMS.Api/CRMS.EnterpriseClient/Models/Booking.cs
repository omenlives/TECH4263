using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.EnterpriseClient.Models
{
    public class Booking
    {
            public int Id { get; set; }

            public int CustomerId { get; set; }

            public int CarId { get; set; }

            public DateTime PickupDate { get; set; }

            public DateTime ReturnDate { get; set; }

            public decimal TotalAmount { get; set; }

            public string Status { get; set; }

            public int? ApprovedById { get; set; }

            public DateTime CreatedAt { get; set; }

            public User Customer { get; set; }

            public Car Car { get; set; }

            public string CustomerName
            {
                get
                {
                    if (Customer == null)
                    {
                        return "";
                    }

                    return Customer.FullName;
                }
            }

            public string CarName
            {
                get
                {
                    if (Car == null)
                    {
                        return "";
                    }

                    return Car.Year + " " + Car.Make + " " + Car.Model;
                }
            }
        }
    }
