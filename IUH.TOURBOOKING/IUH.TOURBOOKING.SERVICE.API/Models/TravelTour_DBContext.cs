using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IUH.TOURBOOKING.SERVICE.API.Models
{
    public partial class TravelTour_DBContext : DbContext
    {
        public TravelTour_DBContext()
        {
        }

        public TravelTour_DBContext(DbContextOptions<TravelTour_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DtAviationDetail> DtAviationDetail { get; set; }
        public virtual DbSet<DtHotelDetail> DtHotelDetail { get; set; }
        public virtual DbSet<DtPaymentDetail> DtPaymentDetail { get; set; }
        public virtual DbSet<DtServiceDetail> DtServiceDetail { get; set; }
        public virtual DbSet<DtSurchargeDetail> DtSurchargeDetail { get; set; }
        public virtual DbSet<DtThemeDetail> DtThemeDetail { get; set; }
        public virtual DbSet<DtTourDetails> DtTourDetails { get; set; }
        public virtual DbSet<DtTourGroupDetail> DtTourGroupDetail { get; set; }
        public virtual DbSet<DtTourGuideDetail> DtTourGuideDetail { get; set; }
        public virtual DbSet<DtVehicleDetail> DtVehicleDetail { get; set; }
        public virtual DbSet<LsAviation> LsAviation { get; set; }
        public virtual DbSet<LsCurrencyUnit> LsCurrencyUnit { get; set; }
        public virtual DbSet<LsCustomerInfo> LsCustomerInfo { get; set; }
        public virtual DbSet<LsDiscount> LsDiscount { get; set; }
        public virtual DbSet<LsHotel> LsHotel { get; set; }
        public virtual DbSet<LsLocation> LsLocation { get; set; }
        public virtual DbSet<LsPayments> LsPayments { get; set; }
        public virtual DbSet<LsService> LsService { get; set; }
        public virtual DbSet<LsSurcharge> LsSurcharge { get; set; }
        public virtual DbSet<LsTheme> LsTheme { get; set; }
        public virtual DbSet<LsTour> LsTour { get; set; }
        public virtual DbSet<LsTourGroup> LsTourGroup { get; set; }
        public virtual DbSet<LsTourGuide> LsTourGuide { get; set; }
        public virtual DbSet<LsVehicle> LsVehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-F752OLD;Initial Catalog=TravelTour_DB;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtAviationDetail>(entity =>
            {
                entity.ToTable("DT_AviationDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AviationId).HasColumnName("AviationID");

                entity.Property(e => e.TourDetailId).HasColumnName("TourDetailID");
            });

            modelBuilder.Entity<DtHotelDetail>(entity =>
            {
                entity.ToTable("DT_HotelDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.TourDetailId).HasColumnName("TourDetailID");
            });

            modelBuilder.Entity<DtPaymentDetail>(entity =>
            {
                entity.ToTable("DT_PaymentDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.TourDetailId).HasColumnName("TourDetailID");
            });

            modelBuilder.Entity<DtServiceDetail>(entity =>
            {
                entity.ToTable("DT_ServiceDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.TourDetailId).HasColumnName("TourDetailID");
            });

            modelBuilder.Entity<DtSurchargeDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DT_SurchargeDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SurchargeId).HasColumnName("SurchargeID");

                entity.Property(e => e.TourDetailId).HasColumnName("TourDetailID");
            });

            modelBuilder.Entity<DtThemeDetail>(entity =>
            {
                entity.ToTable("DT_ThemeDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ThemeId).HasColumnName("ThemeID");

                entity.Property(e => e.TourGroupId).HasColumnName("TourGroupID");
            });

            modelBuilder.Entity<DtTourDetails>(entity =>
            {
                entity.ToTable("DT_TourDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DiscountCodeId)
                    .HasColumnName("DiscountCodeID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SeatBooked)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SeatRemaining)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Seats)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TourId).HasColumnName("TourID");
            });

            modelBuilder.Entity<DtTourGroupDetail>(entity =>
            {
                entity.ToTable("DT_TourGroupDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TourGroupId).HasColumnName("TourGroupID");

                entity.Property(e => e.TourId).HasColumnName("TourID");
            });

            modelBuilder.Entity<DtTourGuideDetail>(entity =>
            {
                entity.ToTable("DT_TourGuideDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TourDetailId).HasColumnName("TourDetailID");

                entity.Property(e => e.TourGuideId).HasColumnName("TourGuideID");
            });

            modelBuilder.Entity<DtVehicleDetail>(entity =>
            {
                entity.ToTable("DT_VehicleDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TourDetailId).HasColumnName("TourDetailId");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            });

            modelBuilder.Entity<LsAviation>(entity =>
            {
                entity.ToTable("LS_Aviation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LsCurrencyUnit>(entity =>
            {
                entity.ToTable("LS_CurrencyUnit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeMoney)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LsCustomerInfo>(entity =>
            {
                entity.ToTable("LS_CustomerInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TourDetailId)
                    .IsRequired()
                    .HasColumnName("TourDetailID")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LsDiscount>(entity =>
            {
                entity.ToTable("LS_Discount");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<LsHotel>(entity =>
            {
                entity.ToTable("LS_Hotel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LsLocation>(entity =>
            {
                entity.ToTable("LS_Location");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TourId)
                    .IsRequired()
                    .HasColumnName("TourID")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LsPayments>(entity =>
            {
                entity.ToTable("LS_Payments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LsService>(entity =>
            {
                entity.ToTable("LS_Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LsSurcharge>(entity =>
            {
                entity.ToTable("LS_Surcharge");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsUsed)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LsTheme>(entity =>
            {
                entity.ToTable("LS_Theme");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.KeyWord)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<LsTour>(entity =>
            {
                entity.ToTable("LS_Tour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Departure)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ends)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Theme)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<LsTourGroup>(entity =>
            {
                entity.ToTable("LS_TourGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Introduce).IsRequired();

                entity.Property(e => e.KeyWord)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<LsTourGuide>(entity =>
            {
                entity.ToTable("LS_TourGuide");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdentityCard)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LsVehicle>(entity =>
            {
                entity.ToTable("LS_Vehicle");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
