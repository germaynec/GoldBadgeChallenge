

public class DeliveryRepoTests
{
    private DeliveryRepository _dRepo = new DeliveryRepository();
    public DeliveryRepoTests()
    {
        DateTime od1 = new DateTime(2023, 2, 24);
        DateTime dd1 = new DateTime(2023, 2, 28);
        Status ds1 = new Status();
        ds1 = Status.Complete;
        Delivery delivery1 = new Delivery(od1, dd1, 20, 2);
        _dRepo.AddDelivery(delivery1);
        _dRepo.UpdateStatusType(delivery1.customerID, ds1);

        DateTime od2 = new DateTime(2023, 5
        , 7);
        DateTime dd2 = new DateTime(2023, 6, 19);
        Status ds2 = new Status();
        ds2 = Status.Scheduled;
        Delivery delivery2 = new Delivery(od2, dd2, 43, 7);
        _dRepo.AddDelivery(delivery2);
        _dRepo.UpdateStatusType(delivery2.customerID, ds2);

        DateTime od3 = new DateTime(2023, 4, 20);
        DateTime dd3 = new DateTime(2023, 5, 11);
        Status ds3 = new Status();
        ds3 = Status.EnRoute;
        Delivery delivery3 = new Delivery(od3, dd3, 69, 4);
        _dRepo.AddDelivery(delivery3);
        _dRepo.UpdateStatusType(delivery3.customerID, ds3);
    }
    [Fact]
    public void AddDelivery_ShouldReturnTrue()
    {
        DateTime od1 = new DateTime(2023, 5, 23);
        DateTime dd1 = new DateTime(2023, 5, 30);
        Delivery deliveryData = new Delivery(od1, od1, 2345, 12);
        deliveryData.DeliveryStatus = Status.Scheduled;

        bool isSuccess = _dRepo.AddDelivery(deliveryData); 

        Assert.True(isSuccess);
    }

    [Fact]
    public void GetDeliveries_ShouldReturnCorrectAmount()
    {
        
        int expected = 3;
        int actual = _dRepo.GetDeliveries().Count();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetEnRouteDeliveries_ShouldReturnCorrectAmount()
    {

        int expected = 1;
        int actual = _dRepo.GetEnRouteDeliveries().Count();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetCompleteDeliveries_ShouldReturnCorrectAmount()
    {
        int expected = 1;
        int actual = _dRepo.GetCompletedDeliveries().Count();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetDeliveryByCustomerId_ShouldReturnCorrectItemNumber()
    {
        var expected = 43;
        var actualItemNumber = _dRepo.GetDeliveryByCustomerId(2).ItemNumber;

        Assert.Equal(expected, actualItemNumber);
    }

    [Fact]
    public void GetStatusType_ShouldReturnCorrectStatus()
    {
        var expected = Status.EnRoute;
        var actualStatus = _dRepo.GetStatusType(_dRepo.GetDeliveryByCustomerId(3));

        Assert.Equal(expected, actualStatus);
    }

    [Fact]
    public void UpdateStatusType_ShouldReturnTrue()
    {
        Delivery newDeliveryData = new Delivery();
        newDeliveryData.DeliveryStatus = Status.Scheduled;

        int deliveryIdToUpdate = 3;

        bool isSuccess = _dRepo.UpdateStatusType(_dRepo.GetDeliveryByCustomerId(deliveryIdToUpdate).customerID, newDeliveryData.DeliveryStatus);

        Assert.True(isSuccess);
    }

    [Fact]
    public void DeleteDelivery_ShouldReturnTrue()
    {
        bool isSuccess = _dRepo.DeleteDelivery(1);
        int expectedCount = 2;
        int actualCount = _dRepo.GetDeliveries().Count();

        Assert.True(isSuccess);
        Assert.Equal(expectedCount, actualCount);
    }
}