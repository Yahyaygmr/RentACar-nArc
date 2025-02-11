﻿using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities
{
    public class Car : Entity<Guid>
    {
        public Guid ModelId { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
        public short MinFindexScore { get; set; }
        public CarState CarState { get; set; }

        public virtual Model? Model { get; set; }

        public Car(Guid id,Guid modelId, CarState carState, int kilometer, short modelYear, string plate, short minFindexScore)
        {
            Id = id;
            ModelId = modelId;
            ModelYear = modelYear;
            Kilometer = kilometer;
            CarState = carState;
            Plate = plate;
            MinFindexScore = minFindexScore;
        }
    }
}
