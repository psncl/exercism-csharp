// https://exercism.org/tracks/csharp/exercises/hyper-optimized-telemetry
// Learn how data types are stored in memory as byte values, and represented in code as hexadecimal values.
// Practice conversion between byte arrays and integral values.

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var result = new byte[9];
        byte[] valueInBytes = GetMinimumBytes(reading);
        result[0] = CalculatePrefixByte(valueInBytes, reading);
        Array.Copy(valueInBytes, 0, result, 1, valueInBytes.Length);
        return result;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefixByte = buffer[0];
        bool prefixIsUnsigned = new[] { sizeof(short), sizeof(int), sizeof(long) }.Contains(prefixByte);
        bool prefixIsSigned = new[] { 256 - sizeof(short), 256 - sizeof(int), 256 - sizeof(long) }.Contains(prefixByte);

        if (!prefixIsUnsigned && !prefixIsSigned) return 0;

        int numberOfBytesToRead = prefixIsUnsigned ? prefixByte : (256 - prefixByte);
        var payload = new byte[numberOfBytesToRead];
        Array.Copy(buffer, 1, payload, 0, numberOfBytesToRead);
        return GetPayloadValue(payload, prefixIsUnsigned);
    }

    private static byte CalculatePrefixByte(byte[] buffer, long inputReading)
    {
        bool isUnsigned =
            inputReading is (<= uint.MaxValue and > int.MaxValue) or (<= ushort.MaxValue and >= ushort.MinValue);
        return isUnsigned ? (byte)buffer.Length : (byte)(256 - buffer.Length);
    }

    private static byte[] GetMinimumBytes(long input)
    {
        return input switch
        {
            > uint.MaxValue => BitConverter.GetBytes(input),
            > int.MaxValue => BitConverter.GetBytes((uint)input),
            > ushort.MaxValue => BitConverter.GetBytes((int)input),
            >= ushort.MinValue => BitConverter.GetBytes((ushort)input),
            >= short.MinValue => BitConverter.GetBytes((short)input),
            >= int.MinValue => BitConverter.GetBytes((int)input),
            < int.MinValue => BitConverter.GetBytes(input)
        };
    }

    private static long GetPayloadValue(byte[] buffer, bool isUnsigned)
    {
        return buffer.Length switch
        {
            sizeof(long) => BitConverter.ToInt64(buffer, 0),
            sizeof(int) when isUnsigned => BitConverter.ToUInt32(buffer, 0),
            sizeof(int) => BitConverter.ToInt32(buffer, 0),
            sizeof(short) when isUnsigned => BitConverter.ToUInt16(buffer, 0),
            sizeof(short) => BitConverter.ToInt16(buffer, 0),
            _ => 0
        };
    }
}