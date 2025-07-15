// See https://aka.ms/new-console-template for more information

 using EnqueuingTask;

 Queue<OrcEvent> queue1 = new Queue<OrcEvent>();
        queue1.Enqueue(new OrcEvent { Name = "Orc Gathering", DateTime = DateTime.Now });
        queue1.Enqueue(new OrcEvent { Name = "Orc Meeting", DateTime = DateTime.Now.AddMinutes(10) });
        queue1.Enqueue(new OrcEvent { Name = "Orc Warplan", DateTime = DateTime.Now.AddMinutes(20) });
        queue1.Enqueue(new OrcEvent { Name = "Orc Rest", DateTime = DateTime.Now.AddMinutes(30) });
        queue1.Enqueue(new OrcEvent { Name = "Orc Charge", DateTime = DateTime.Now.AddMinutes(40) });

        // Queue 2
        Queue<OrcEvent> queue2 = new Queue<OrcEvent>();
        queue2.Enqueue(new OrcEvent { Name = "Orc Celebration", DateTime = DateTime.Now.AddHours(1) });
        queue2.Enqueue(new OrcEvent { Name = "Orc Banquet", DateTime = DateTime.Now.AddHours(1.5) });
        queue2.Enqueue(new OrcEvent { Name = "Orc Dance", DateTime = DateTime.Now.AddHours(2) });
        queue2.Enqueue(new OrcEvent { Name = "Orc Feast", DateTime = DateTime.Now.AddHours(2.5) });
        queue2.Enqueue(new OrcEvent { Name = "Orc Toast", DateTime = DateTime.Now.AddHours(3) });

        // Queue 3
        Queue<OrcEvent> queue3 = new Queue<OrcEvent>();
        queue3.Enqueue(new OrcEvent { Name = "Orc Migration", DateTime = DateTime.Now.AddDays(1) });
        queue3.Enqueue(new OrcEvent { Name = "Orc Scouting", DateTime = DateTime.Now.AddDays(1).AddHours(1) });
        queue3.Enqueue(new OrcEvent { Name = "Orc Strategy", DateTime = DateTime.Now.AddDays(1).AddHours(2) });
        queue3.Enqueue(new OrcEvent { Name = "Orc Campfire Story", DateTime = DateTime.Now.AddDays(1).AddHours(3) });
        queue3.Enqueue(new OrcEvent { Name = "Orc Night Patrol", DateTime = DateTime.Now.AddDays(1).AddHours(4) });

        // Queue 4
        Queue<OrcEvent> queue4 = new Queue<OrcEvent>();
        queue4.Enqueue(new OrcEvent { Name = "Orc War Cry", DateTime = DateTime.Now.AddDays(2) });
        queue4.Enqueue(new OrcEvent { Name = "Orc Battle Preparation", DateTime = DateTime.Now.AddDays(2).AddHours(1) });
        queue4.Enqueue(new OrcEvent { Name = "Orc Recon", DateTime = DateTime.Now.AddDays(2).AddHours(2) });
        queue4.Enqueue(new OrcEvent { Name = "Orc Siege", DateTime = DateTime.Now.AddDays(2).AddHours(3) });
        queue4.Enqueue(new OrcEvent { Name = "Orc Victory Parade", DateTime = DateTime.Now.AddDays(2).AddHours(4) });

        // Queue 5
        Queue<OrcEvent> queue5 = new Queue<OrcEvent>();
        queue5.Enqueue(new OrcEvent { Name = "Orc Speech", DateTime = DateTime.Now.AddDays(3) });
        queue5.Enqueue(new OrcEvent { Name = "Orc Training Session", DateTime = DateTime.Now.AddDays(3).AddHours(1) });
        queue5.Enqueue(new OrcEvent { Name = "Orc Target Practice", DateTime = DateTime.Now.AddDays(3).AddHours(2) });
        queue5.Enqueue(new OrcEvent { Name = "Orc Hunting", DateTime = DateTime.Now.AddDays(3).AddHours(3) });
        queue5.Enqueue(new OrcEvent { Name = "Orc Retreat", DateTime = DateTime.Now.AddDays(3).AddHours(4) });


        var queues = new List<Queue<OrcEvent>>();
        queues.Add(queue1);
        queues.Add(queue2);
        queues.Add(queue3);
        queues.Add(queue4);
        queues.Add(queue5);
        
        var process = new ProcessQueues(queues);
        process.Execute();