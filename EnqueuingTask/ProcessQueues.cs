namespace EnqueuingTask;

public class OrcEvent
{
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
}

public class ProcessQueues
{
    private List<Queue<OrcEvent>> InBoundQueue { get; set; }
    private Queue<OrcEvent> OutBoundQueue { get; set; }
    private OrcEvent[] InMemoryOrcEvents { get; set; }

    public ProcessQueues(List<Queue<OrcEvent>> inBoundQueues)
    {
        InBoundQueue = inBoundQueues;
        OutBoundQueue = new Queue<OrcEvent>();
        InMemoryOrcEvents = new OrcEvent[3];
    }

    public void Execute()
    {
        foreach (var queue in InBoundQueue)
        {
            int queueCounter = 0;
            while (queueCounter <= 5)
            {

                queueCounter++;
                var place = false;
                var orcEvent = queue.Dequeue(); //grab the next event from the queue

                for (int i = 0; i < InMemoryOrcEvents.Length; i++)
                {
                    if (InMemoryOrcEvents[i] is null) //
                    {
                        //write only non-null element sto the array
                        InMemoryOrcEvents[i] = orcEvent; //place the event and 
                        place = true;
                        break; // exist the loop
                    }

                    //if the current position is not null, compare the datetime
                    if (orcEvent.DateTime > InMemoryOrcEvents[i].DateTime)
                    {
                        var existingEvent = InMemoryOrcEvents[i]; //grab the occupied event to temp variable
                        InMemoryOrcEvents[i] = orcEvent;
                        MoveEventRight(existingEvent, i + 1, queue);
                        place = true;
                        break;
                    }
                }

                if (!place)
                    queue.Enqueue(orcEvent);
            }
        }

        foreach (var orcEvent in InMemoryOrcEvents)
        {
            if (orcEvent != null)
                OutBoundQueue.Enqueue(orcEvent);
        }
    }

    private void MoveEventRight(OrcEvent eventToMove, int startIndex, Queue<OrcEvent> queue)
    {
        for (int i = startIndex; i < InMemoryOrcEvents.Length; i++)
        {
            if (InMemoryOrcEvents[i] == null) //if there's an empty slot
            {
                InMemoryOrcEvents[i] = eventToMove;
                return;
            }

            //if the slot is occupied, continue sliding
            var displacedEvent = InMemoryOrcEvents[i];
            InMemoryOrcEvents[i] = eventToMove;
            eventToMove = displacedEvent;
        }

        queue.Enqueue(eventToMove);
    }
}