using SharedKernel;

namespace FrontDesk.Core.ScheduleAggreagate;

public class Appointment : BaseEntity<Guid>
{
    public Appointment(Guid id,
        int appointmentTypeId,
        Guid scheduleId,
        int clientId,
        int doctorId,
        int patientId,
        int roomId,
        DateTimeOffsetRange timeRange,
        string title,
        DateTime? dateTimeConfirmed = null)
    {
        
    }
}