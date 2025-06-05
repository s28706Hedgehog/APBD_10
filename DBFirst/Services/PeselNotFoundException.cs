namespace DBFirst.Services;

public class PeselNotFoundException() : Exception("Client with specified pesel does not exist");