public class Delivery
{
    public Delivery()
    {

    }
    public Delivery(DateTime orderDate, DateTime deliveryDate, int itemNumber, int itemQuantity)
    {
        OrderDate = orderDate;
        DeliveryDate = deliveryDate;
        ItemNumber = itemNumber;
        ItemQuantity = itemQuantity;
    }

    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public int ItemNumber { get; set; }
    public int ItemQuantity { get; set; }
    public int customerID { get; set; }


    public Status DeliveryStatus { get; set; }
    

    public override string ToString()
    {
        string str = $"Delivery for Item Number: {ItemNumber}\n" +
        $"Order was placed on: {OrderDate}\n" +
        $"Order is scheduled for: {DeliveryDate}\n" +
        $"Item number: {ItemNumber} | Quantity: {ItemQuantity}\n" +
        $"Customer ID: {customerID}\n" +
        $"Status of Order: {DeliveryStatus}\n" +
        "==========================================\n";
        return str;
    }
}
