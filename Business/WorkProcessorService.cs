using Business.Domain;
using Business.Interfaces;

namespace Business
{
    public class WorkProcessorService: IWorkProcessorService
    {
        public string ProcessOrder(OrderDetail orderDetail, List<Employee> employees)
        {
            string totalTimeTaken =string.Empty;

            if (employees!=null)
            {
                double? largeItemTimeTake = 0, mediumItemTimeTake = 0, smallItemTimeTake = 0;
                Employee employee1 = null, employee2 = null, employee3 = null;

                if (orderDetail.LargeItemCount>orderDetail.MediumItemCount*2 && orderDetail.LargeItemCount>orderDetail.SmallItemCount*4)
                {
                    employee1 = employees.FirstOrDefault(x => x.LargeItem=="VG");
                    employee1 =employee1!=null ? employee1 : employees.FirstOrDefault(x => x.LargeItem=="G");
                    employee1 =employee1!=null ? employee1 : employees.FirstOrDefault(x => x.LargeItem=="B");
                    largeItemTimeTake = orderDetail.LargeItemCount*employee1?.LargeItemScore;

                    if (orderDetail.MediumItemCount*2>orderDetail.SmallItemCount*4)
                    {
                        employee2 = employees.FirstOrDefault(x => x.MediumItem=="VG"  && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.MediumItem=="G" && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.MediumItem=="B" && x!=employee1);

                        employee3 = employees.FirstOrDefault(x => x.SmallItem=="VG"  && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.SmallItem=="G" && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.SmallItem=="B" && x!=employee1 && x!=employee2);
                        mediumItemTimeTake = orderDetail.MediumItemCount*employee2?.MediumItemScore;
                        smallItemTimeTake = orderDetail.SmallItemCount*employee3?.SmallItemScore;
                    }
                    else
                    {
                        employee2 = employees.FirstOrDefault(x => x.SmallItem=="VG"  && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.SmallItem=="G" && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.SmallItem=="B" && x!=employee1);

                        employee3 = employees.FirstOrDefault(x => x.MediumItem=="VG"  && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.MediumItem=="G" && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.MediumItem=="B" && x!=employee1 && x!=employee2);
                        mediumItemTimeTake = orderDetail.MediumItemCount*employee3?.MediumItemScore;
                        smallItemTimeTake = orderDetail.SmallItemCount*employee2?.SmallItemScore;
                    }
                }

                if (orderDetail.MediumItemCount*2>orderDetail.LargeItemCount && orderDetail.MediumItemCount*2>orderDetail.SmallItemCount*4)
                {
                    employee1 = employees.FirstOrDefault(x => x.MediumItem=="VG");
                    employee1 =employee1!=null ? employee1 : employees.FirstOrDefault(x => x.MediumItem=="G");
                    employee1 =employee1!=null ? employee1 : employees.FirstOrDefault(x => x.MediumItem=="B");
                    mediumItemTimeTake = orderDetail.MediumItemCount*employee1?.MediumItemScore;

                    if (orderDetail.LargeItemCount>orderDetail.SmallItemCount*4)
                    {
                        employee2 = employees.FirstOrDefault(x => x.LargeItem=="VG"  && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.LargeItem=="G" && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.LargeItem=="B" && x!=employee1);

                        employee3 = employees.FirstOrDefault(x => x.SmallItem=="VG"  && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.SmallItem=="G" && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.SmallItem=="B" && x!=employee1 && x!=employee2);

                        EmployeeCoverUp(employee1, ref employee2, ref employee3);
                        largeItemTimeTake = orderDetail.LargeItemCount*employee2?.LargeItemScore;
                        smallItemTimeTake = orderDetail.SmallItemCount*employee3?.SmallItemScore;
                    }
                    else
                    {
                        employee2 = employees.FirstOrDefault(x => x.SmallItem=="VG"  && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.SmallItem=="G" && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.SmallItem=="B" && x!=employee1);

                        employee3 = employees.FirstOrDefault(x => x.LargeItem=="VG"  && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.LargeItem=="G" && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.LargeItem=="B" && x!=employee1 && x!=employee2);

                        EmployeeCoverUp(employee1, ref employee2, ref employee3);
                        largeItemTimeTake = orderDetail.LargeItemCount*employee3?.LargeItemScore;
                        smallItemTimeTake = orderDetail.SmallItemCount*employee2?.SmallItemScore;
                    }
                }

                if (orderDetail.SmallItemCount*4>orderDetail.LargeItemCount && orderDetail.SmallItemCount*4>orderDetail.MediumItemCount*2)
                {
                    employee1 = employees.FirstOrDefault(x => x.SmallItem=="VG");
                    employee1 =employee1!=null ? employee1 : employees.FirstOrDefault(x => x.SmallItem=="G");
                    employee1 =employee1!=null ? employee1 : employees.FirstOrDefault(x => x.SmallItem=="B");
                    smallItemTimeTake = orderDetail.SmallItemCount*employee1?.SmallItemScore;

                    if (orderDetail.LargeItemCount>orderDetail.MediumItemCount*2)
                    {
                        employee2 = employees.FirstOrDefault(x => x.LargeItem=="VG"  && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.LargeItem=="G" && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.LargeItem=="B" && x!=employee1);

                        employee3 = employees.FirstOrDefault(x => x.MediumItem=="VG"  && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.MediumItem=="G" && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.MediumItem=="B" && x!=employee1 && x!=employee2);

                        EmployeeCoverUp(employee1, ref employee2, ref employee3);
                        largeItemTimeTake = orderDetail.LargeItemCount*employee2?.LargeItemScore;
                        mediumItemTimeTake = orderDetail.MediumItemCount*employee3?.MediumItemScore;
                    }
                    else
                    {
                        employee2 = employees.FirstOrDefault(x => x.MediumItem=="VG"  && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.MediumItem=="G" && x!=employee1);
                        employee2 =employee2!=null ? employee2 : employees.FirstOrDefault(x => x.MediumItem=="B" && x!=employee1);

                        employee3 = employees.FirstOrDefault(x => x.LargeItem=="VG"  && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.LargeItem=="G" && x!=employee1 && x!=employee2);
                        employee3 =employee3!=null ? employee3 : employees.FirstOrDefault(x => x.LargeItem=="B" && x!=employee1 && x!=employee2);

                        EmployeeCoverUp(employee1, ref employee2, ref employee3);
                        largeItemTimeTake = orderDetail.LargeItemCount*employee3?.LargeItemScore;
                        mediumItemTimeTake = orderDetail.MediumItemCount*employee2?.MediumItemScore;
                    }
                }

                if (employee1!=null)
                {
                    double? minutes = largeItemTimeTake+mediumItemTimeTake+smallItemTimeTake;
                    double totalMinutes = minutes!=null ? minutes.Value:0;
                    double hours =totalMinutes/60;
                    
                    totalTimeTaken=hours.ToString();
                }
            }

            return totalTimeTaken;
        }

        private static void EmployeeCoverUp(Employee employee1, ref Employee employee2, ref Employee employee3)
        {
            if (employee2==null)
            {
                employee2=employee1;
            }

            if (employee3==null)
            {
                employee3=employee2;
            }
        }
    }
}
