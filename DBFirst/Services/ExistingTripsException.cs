namespace DBFirst.Services;

public class ExistingTripsException(int clientId)
    : Exception($"Can't delete client with trips assigned. Client id: {clientId}");