USE [SalesOrderDB]
GO

/****** Object:  Table [dbo].[OrderProductDetails]    Script Date: 16/02/2023 3:08:42 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderProductDetails](
	[SalesOrder] [nvarchar](10) NOT NULL,
	[SalesOrderItem] [nvarchar](10) NOT NULL,
	[WorkOrder] [nvarchar](10) NOT NULL,
	[ProductID] [nvarchar](20) NOT NULL,
	[ProductDescription] [nvarchar](4000) NOT NULL,
	[OrderQty] [decimal](10, 0) NOT NULL,
	[OrderStatus] [nvarchar](10) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderProductDetails] PRIMARY KEY CLUSTERED 
(
	[WorkOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderProductDetails] ADD  CONSTRAINT [DF_OrderProductDetails_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO

SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spAddOrder]    Script Date: 2/16/2023 3:13:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spAddOrder]        
(        
    @SalesOrder NVARCHAR(10),         
    @SalesOrderItem NVARCHAR(10),        
    @WorkOrder NVARCHAR(10),        
    @ProductID NVARCHAR(20),
	@ProductDescription NVARCHAR(4000),
	@OrderQty DECIMAL(10,0),
	@OrderStatus NVARCHAR(10),
	@Timestamp DATETIME
)        
as         
Begin         
    Insert into OrderProductDetails (SalesOrder, SalesOrderItem, WorkOrder, ProductID, ProductDescription, OrderQty, OrderStatus, Timestamp)         
    Values (@SalesOrder, @SalesOrderItem, @WorkOrder, @ProductID, @ProductDescription, @OrderQty, @OrderStatus, @Timestamp)         
End
GO

/****** Object:  StoredProcedure [dbo].[spDeleteOrder]    Script Date: 2/16/2023 3:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteOrder]         
(          
   @WorkOrder NVARCHAR(10)          
)          
as           
begin          
   Delete from OrderProductDetails where WorkOrder=@WorkOrder         
End
GO

/****** Object:  StoredProcedure [dbo].[spGetAllOrder]    Script Date: 2/16/2023 3:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetAllOrder]      
as      
Begin      
    select *      
    from OrderProductDetails   
    order by WorkOrder 
End
GO

/****** Object:  StoredProcedure [dbo].[spUpdateOrder]    Script Date: 2/16/2023 3:23:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[spUpdateOrder]          
(          
    @SalesOrder NVARCHAR(10),         
    @SalesOrderItem NVARCHAR(10),        
    @WorkOrder NVARCHAR(10),        
    @ProductID NVARCHAR(20),
	@ProductDescription NVARCHAR(4000),
	@OrderQty DECIMAL(10,0),
	@OrderStatus NVARCHAR(10),
	@Timestamp DATETIME          
)          
as          
begin          
   Update OrderProductDetails           
   set         
   SalesOrder=@SalesOrder,
   SalesOrderItem=@SalesOrderItem,
   ProductID=@ProductID,
   ProductDescription=@ProductDescription,
   OrderQty=@OrderQty,
   OrderStatus=@OrderStatus,
   Timestamp=@Timestamp
   where WorkOrder=@WorkOrder          
End
GO