using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace airplanereservationsystem.Models
{
    public partial class airplanereservationsystemContext : DbContext
    {
        public airplanereservationsystemContext()
        {
        }

        public airplanereservationsystemContext(DbContextOptions<airplanereservationsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessTo> AccessTo { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<AirlineCompany> AirlineCompany { get; set; }
        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<AirplaneRoute> AirplaneRoute { get; set; }
        public virtual DbSet<AirplaneType> AirplaneType { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Arrival> Arrival { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Departure> Departure { get; set; }
        public virtual DbSet<Flies> Flies { get; set; }
        public virtual DbSet<FlightLeg> FlightLeg { get; set; }
        public virtual DbSet<GetsInfoFrom> GetsInfoFrom { get; set; }
        public virtual DbSet<GoesTo> GoesTo { get; set; }
        public virtual DbSet<LegInstance> LegInstance { get; set; }
        public virtual DbSet<Owns> Owns { get; set; }
        public virtual DbSet<Provides> Provides { get; set; }
        public virtual DbSet<ReseverationSystem> ReseverationSystem { get; set; }
        public virtual DbSet<RunBy> RunBy { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=airplanereservationsystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessTo>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PRIMARY");

                entity.ToTable("access to");

                entity.HasIndex(e => e.AdminId)
                    .HasName("fk_adminID_idx");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("fk_custID_idx");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.HasOne(d => d.Admin)
                    .WithOne(p => p.AccessTo)
                    .HasForeignKey<AccessTo>(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_adminID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AccessTo)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_custID");
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PRIMARY");

                entity.ToTable("administrator");

                entity.HasIndex(e => e.ReservationSystemId)
                    .HasName("fk_res_system_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_user_id _idx");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.Property(e => e.UserId).HasColumnName("user_ID");

                entity.HasOne(d => d.ReservationSystem)
                    .WithMany(p => p.Administrator)
                    .HasForeignKey(d => d.ReservationSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_res_system");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Administrator)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userid ");
            });

            modelBuilder.Entity<AirlineCompany>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("airline company");

                entity.HasIndex(e => e.ReservationSystemId)
                    .HasName("fk_reservation_sys_idx");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AirlineCode)
                    .HasColumnName("Airline_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.HqCity)
                    .HasColumnName("HQ_City")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.HasOne(d => d.ReservationSystem)
                    .WithMany(p => p.AirlineCompany)
                    .HasForeignKey(d => d.ReservationSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservation_sys");
            });

            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.ToTable("airplane");

                entity.HasIndex(e => e.AirlineCompanyName)
                    .HasName("airline_company_name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ModelType)
                    .HasName("model_type_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.AirplaneId).HasColumnName("airplane_id");

                entity.Property(e => e.AirlineCompanyName)
                    .IsRequired()
                    .HasColumnName("airline_company_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ModelType)
                    .IsRequired()
                    .HasColumnName("model_type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pilot)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TotalNumSeats).HasColumnName("total_num_seats");
            });

            modelBuilder.Entity<AirplaneRoute>(entity =>
            {
                entity.HasKey(e => e.RouteNum)
                    .HasName("PRIMARY");

                entity.ToTable("airplane route");

                entity.HasIndex(e => e.AirportCode)
                    .HasName("fk_airport_code_idx");

                entity.Property(e => e.RouteNum).HasColumnName("route_num");

                entity.Property(e => e.AirportCode)
                    .IsRequired()
                    .HasColumnName("airport_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AmountOfTime)
                    .HasColumnName("amount_of_time")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.AirplaneRoute)
                    .HasForeignKey(d => d.AirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_airport_code");
            });

            modelBuilder.Entity<AirplaneType>(entity =>
            {
                entity.HasKey(e => e.AirplaneId)
                    .HasName("PRIMARY");

                entity.ToTable("airplane type");

                entity.HasIndex(e => e.ModelType)
                    .HasName("fk_model_id_idx");

                entity.Property(e => e.AirplaneId).HasColumnName("airplane_id");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.MaxSeats).HasColumnName("max_seats");

                entity.Property(e => e.ModelType)
                    .IsRequired()
                    .HasColumnName("model_type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Airplane)
                    .WithOne(p => p.AirplaneTypeAirplane)
                    .HasForeignKey<AirplaneType>(d => d.AirplaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_airplane_id");

                entity.HasOne(d => d.ModelTypeNavigation)
                    .WithMany(p => p.AirplaneTypeModelTypeNavigation)
                    .HasPrincipalKey(p => p.ModelType)
                    .HasForeignKey(d => d.ModelType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_model_type");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.AirportCode)
                    .HasName("PRIMARY");

                entity.ToTable("airport");

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProvinceState)
                    .HasColumnName("province/state")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Arrival>(entity =>
            {
                entity.HasKey(e => new { e.AirportCode, e.LegNum, e.RouteNum })
                    .HasName("PRIMARY");

                entity.ToTable("arrival");

                entity.HasIndex(e => e.LegNum)
                    .HasName("fk_arr_legnum_idx");

                entity.HasIndex(e => e.RouteNum)
                    .HasName("fk_arr_routenum_idx");

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LegNum).HasColumnName("Leg_num");

                entity.Property(e => e.RouteNum).HasColumnName("Route_num");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ScheduleArrTime)
                    .HasColumnName("schedule_arr_time")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.Arrival)
                    .HasForeignKey(d => d.AirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arr_airportcode");

                entity.HasOne(d => d.LegNumNavigation)
                    .WithMany(p => p.ArrivalLegNumNavigation)
                    .HasForeignKey(d => d.LegNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arr_legnum");

                entity.HasOne(d => d.RouteNumNavigation)
                    .WithMany(p => p.ArrivalRouteNumNavigation)
                    .HasPrincipalKey(p => p.RouteNum)
                    .HasForeignKey(d => d.RouteNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arr_routenum");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.ReservationSystemId)
                    .HasName("fk_reservation_id_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_user_id_idx");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasColumnName("phone_num")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.Property(e => e.ReturnUrl)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.ReservationSystem)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.ReservationSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservation_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_id");
            });

            modelBuilder.Entity<Departure>(entity =>
            {
                entity.HasKey(e => new { e.AirportCode, e.LegNum, e.RouteNum })
                    .HasName("PRIMARY");

                entity.ToTable("departure");

                entity.HasIndex(e => e.LegNum)
                    .HasName("fk_dep_legnum_idx");

                entity.HasIndex(e => e.RouteNum)
                    .HasName("fk_routenum_idx");

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LegNum).HasColumnName("Leg_num");

                entity.Property(e => e.RouteNum).HasColumnName("Route_num");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ScheduleDepTime)
                    .HasColumnName("schedule_dep_time")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.Departure)
                    .HasForeignKey(d => d.AirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_airportcode");

                entity.HasOne(d => d.LegNumNavigation)
                    .WithMany(p => p.DepartureLegNumNavigation)
                    .HasForeignKey(d => d.LegNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_legnum");

                entity.HasOne(d => d.RouteNumNavigation)
                    .WithMany(p => p.DepartureRouteNumNavigation)
                    .HasPrincipalKey(p => p.RouteNum)
                    .HasForeignKey(d => d.RouteNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dep_routenum");
            });

            modelBuilder.Entity<Flies>(entity =>
            {
                entity.HasKey(e => new { e.AirplaneId, e.RouteNum })
                    .HasName("PRIMARY");

                entity.ToTable("flies");

                entity.HasIndex(e => e.RouteNum)
                    .HasName("fk_rnum_idx");

                entity.Property(e => e.AirplaneId).HasColumnName("airplane_id");

                entity.Property(e => e.RouteNum).HasColumnName("route_num");

                entity.HasOne(d => d.Airplane)
                    .WithMany(p => p.Flies)
                    .HasForeignKey(d => d.AirplaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_aid");

                entity.HasOne(d => d.RouteNumNavigation)
                    .WithMany(p => p.Flies)
                    .HasForeignKey(d => d.RouteNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rnum");
            });

            modelBuilder.Entity<FlightLeg>(entity =>
            {
                entity.HasKey(e => e.LegNum)
                    .HasName("PRIMARY");

                entity.ToTable("flight leg");

                entity.HasIndex(e => e.RouteNum)
                    .HasName("Route_num_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.LegNum).HasColumnName("Leg_num");

                entity.Property(e => e.RouteNum).HasColumnName("route_num");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.RouteNumNavigation)
                    .WithOne(p => p.FlightLeg)
                    .HasForeignKey<FlightLeg>(d => d.RouteNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_route_num");
            });

            modelBuilder.Entity<GetsInfoFrom>(entity =>
            {
                entity.HasKey(e => new { e.ReservationSystemId, e.AirlineCompanyName, e.AirportCode })
                    .HasName("PRIMARY");

                entity.ToTable("gets info from");

                entity.HasIndex(e => e.AirlineCompanyName)
                    .HasName("fk_gif_airlineCompanyName_idx");

                entity.HasIndex(e => e.AirportCode)
                    .HasName("fk_gif_airportcode_idx");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.Property(e => e.AirlineCompanyName)
                    .HasColumnName("airline_company_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AirlineCompanyNameNavigation)
                    .WithMany(p => p.GetsInfoFrom)
                    .HasPrincipalKey(p => p.AirlineCompanyName)
                    .HasForeignKey(d => d.AirlineCompanyName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gif_airlineCompanyName");

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.GetsInfoFrom)
                    .HasForeignKey(d => d.AirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gif_airportcode");

                entity.HasOne(d => d.ReservationSystem)
                    .WithMany(p => p.GetsInfoFrom)
                    .HasForeignKey(d => d.ReservationSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gif_reservationid");
            });

            modelBuilder.Entity<GoesTo>(entity =>
            {
                entity.HasKey(e => new { e.AirportCode, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("goes to");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_userid_idx");

                entity.Property(e => e.AirportCode)
                    .HasColumnName("airport_code")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.AirportCodeNavigation)
                    .WithMany(p => p.GoesTo)
                    .HasForeignKey(d => d.AirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gt_airportcode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GoesTo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gt_userid");
            });

            modelBuilder.Entity<LegInstance>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.LegNum })
                    .HasName("PRIMARY");

                entity.ToTable("leg instance");

                entity.HasIndex(e => e.LegNum)
                    .HasName("fk_legnum_idx");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LegNum).HasColumnName("leg_num");

                entity.Property(e => e.AirplaneId)
                    .HasColumnName("airplane_id")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NoAvailSeats).HasColumnName("No_avail_seats");

                entity.Property(e => e.RouteNum).HasColumnName("route_num");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.LegNumNavigation)
                    .WithMany(p => p.LegInstance)
                    .HasForeignKey(d => d.LegNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_legno");
            });

            modelBuilder.Entity<Owns>(entity =>
            {
                entity.HasKey(e => new { e.AirplaneId, e.AirlineCompanyName })
                    .HasName("PRIMARY");

                entity.ToTable("owns");

                entity.HasIndex(e => e.AirlineCompanyName)
                    .HasName("fk_airline_company_name_idx");

                entity.HasIndex(e => e.AirplaneId)
                    .HasName("fk_airId_idx");

                entity.Property(e => e.AirplaneId).HasColumnName("airplane_id");

                entity.Property(e => e.AirlineCompanyName)
                    .HasColumnName("airline_company_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.AirlineCompanyNameNavigation)
                    .WithMany(p => p.OwnsAirlineCompanyNameNavigation)
                    .HasPrincipalKey(p => p.AirlineCompanyName)
                    .HasForeignKey(d => d.AirlineCompanyName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_airplane_company_name");

                entity.HasOne(d => d.Airplane)
                    .WithMany(p => p.OwnsAirplane)
                    .HasForeignKey(d => d.AirplaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_airId");
            });

            modelBuilder.Entity<Provides>(entity =>
            {
                entity.HasKey(e => new { e.ReservationSystemId, e.LegNumber, e.TicketNumber })
                    .HasName("PRIMARY");

                entity.ToTable("provides");

                entity.HasIndex(e => e.LegNumber)
                    .HasName("fk_legnum_idx");

                entity.HasIndex(e => e.TicketNumber)
                    .HasName("fk_ticketnum_idx");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.Property(e => e.LegNumber).HasColumnName("leg_number");

                entity.Property(e => e.TicketNumber).HasColumnName("ticket_number");

                entity.HasOne(d => d.LegNumberNavigation)
                    .WithMany(p => p.Provides)
                    .HasForeignKey(d => d.LegNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_legnum");

                entity.HasOne(d => d.ReservationSystem)
                    .WithMany(p => p.Provides)
                    .HasForeignKey(d => d.ReservationSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_res");

                entity.HasOne(d => d.TicketNumberNavigation)
                    .WithMany(p => p.Provides)
                    .HasForeignKey(d => d.TicketNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ticketnum");
            });

            modelBuilder.Entity<ReseverationSystem>(entity =>
            {
                entity.HasKey(e => e.ReservationSystemId)
                    .HasName("PRIMARY");

                entity.ToTable("reseveration system");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.Property(e => e.CheckInStatus)
                    .HasColumnName("check_in_status")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("Customer_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.JobNo).HasColumnName("job_no");
            });

            modelBuilder.Entity<RunBy>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PRIMARY");

                entity.ToTable("run by");

                entity.HasIndex(e => e.AdminId)
                    .HasName("fk_admin_id_idx");

                entity.HasIndex(e => e.ReservationSystemId)
                    .HasName("fk_reservation_idx");

                entity.Property(e => e.AdminId).HasColumnName("Admin_ID");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.HasOne(d => d.Admin)
                    .WithOne(p => p.RunBy)
                    .HasForeignKey<RunBy>(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_admin_id");

                entity.HasOne(d => d.ReservationSystem)
                    .WithMany(p => p.RunBy)
                    .HasForeignKey(d => d.ReservationSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reservation");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketNumber)
                    .HasName("PRIMARY");

                entity.ToTable("ticket");

                entity.HasIndex(e => e.ReservationSystemId)
                    .HasName("fk_system_res _idx");

                entity.Property(e => e.TicketNumber).HasColumnName("Ticket_number");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ClassType)
                    .HasColumnName("class_type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Date)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateIssued)
                    .HasColumnName("Date_issued")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LegNum).HasColumnName("Leg_num");

                entity.Property(e => e.ReservationSystemId).HasColumnName("reservation_system_id");

                entity.Property(e => e.SeatNum).HasColumnName("seat_num");

                entity.HasOne(d => d.ReservationSystem)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.ReservationSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_system_res ");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
