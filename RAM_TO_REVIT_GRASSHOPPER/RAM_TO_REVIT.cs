using RAM_TO_REVIT_GRASSHOPPER;
using Grasshopper.Kernel;
using RAMDATAACCESSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Grasshopper.Kernel.Parameters;
using System.Security.Cryptography.X509Certificates;
using Rhino.Geometry;

namespace RAM_TO_REVIT_GRASSHOPPER
{
    public class GET_FLOOR_TYPE_COUNT : GH_Component
    {

        public GET_FLOOR_TYPE_COUNT() : base("GET_FLOOR_TYPE_COUNT", "GFTC", "Get floor type count", "RAM", "Floor")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("C2D7586C-266F-40B4-B4A8-E7510FA67996"); }
        }
        public static GET_FLOOR_TYPE_COUNT Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM file path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("FloorTypeCount", "C", "Number of floor types in model", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName)) {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");


            IFloorTypes My_floortypes = IModel.GetFloorTypes();

            int My_floortype_count = My_floortypes.GetCount();

            //CLOSE
            IDBI.CloseDatabase();
            DA.SetData("FloorTypeCount", My_floortype_count);
        }
    }

    public class GET_FLOOR_TYPE_IDS : GH_Component
    {

        public GET_FLOOR_TYPE_IDS() : base("GET_FLOOR_TYPE_IDS", "GFTIDs", "Get the floor type Identifiers", "RAM", "Floor")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("03EA8647-7021-459D-AFC8-DD61FAF07D79"); }
        }
        public static GET_FLOOR_TYPE_IDS Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM file path", GH_ParamAccess.item);
            pManager.AddNumberParameter("TotalNumOfFlrTypeInListFormat", "TNFT", "List of floor types", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("FloorTypeID", "FTID", "Floor Type ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN

            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }

            int TotalNumOfFlrTypeInListFormat = 0;
            if (!DA.GetData("TotalNumOfFlrTypeInListFormat", ref TotalNumOfFlrTypeInListFormat)) 
            {
                return;
            } 
            if (TotalNumOfFlrTypeInListFormat == 0)
            {
                return;
            }

            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();

            IFloorType My_floortype = My_floortypes.GetAt(TotalNumOfFlrTypeInListFormat);
            int My_FloorType_ID = My_floortype.lUID;
            //  
            IDBI.CloseDatabase();
            DA.SetData("FloorTypeID", My_FloorType_ID);
        }
    }


    public class SET_FLOOR_TYPE : GH_Component
    {

        public SET_FLOOR_TYPE() : base("SET_FLOOR_TYPE", "SFT", "Set Floor Type", "RAM", "Floor")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("3EE55B6E-4D64-4359-946B-1CAFC86C6187"); }
        }
        public static SET_FLOOR_TYPE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM File Path", GH_ParamAccess.item);
            pManager.AddTextParameter("FloorTypeName", "FTN", "Floor Type Name", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("FloorTypeID", "FTID", "Floor Type ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }

            string FloorTypeName = null;
            if (!DA.GetData("FloorTypeName", ref FloorTypeName))
            {
                return;
            }
            if (FloorTypeName == null || FloorTypeName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_New_floortype = My_floortypes.Add(FloorTypeName);
            int MyFlrTypeID = My_New_floortype.lUID;
            DA.SetData("FloorTypeID", MyFlrTypeID);

            //CLOSE
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();

        }
    }

    public class GET_STORY_COUNT : GH_Component
    {

        public GET_STORY_COUNT() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Story")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("FF24E6AA-6701-4365-BE20-074DAC1EAD1D"); }
        }
        public static GET_FLOOR_TYPE_COUNT Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM File Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("My_story_count", "MSC", "My story count", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            DA.SetData("My_story_count", My_story_count);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_CL : GH_Component
    {

        public GET_RAM_COL_CL() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Column")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("DC579175-5B31-4E92-B8AB-0F1D2B7D8ED3"); }
        }
        public static GET_RAM_COL_CL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();
            SCoordinate P1 = new SCoordinate();
            SCoordinate P2 = new SCoordinate();
            List<Rhino.Geometry.Line> ListLine = new List<Rhino.Geometry.Line>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                My_Story.GetColumns().GetAt(i).GetEndCoordinates(ref P1, ref P2);
                double P1x = P1.dXLoc;
                double P1y = P1.dYLoc;
                double P1z = P1.dZLoc;
                double P2x = P2.dXLoc;
                double P2y = P2.dYLoc;
                double P2z = P2.dZLoc;
                Rhino.Geometry.Point3d PD1 =
                        new Rhino.Geometry.Point3d(P1x, P1y, P1z);
                Rhino.Geometry.Point3d PD2 =
                        new Rhino.Geometry.Point3d(P2x, P2y, P2z);
                Rhino.Geometry.Line Dline =
                    new Rhino.Geometry.Line(PD1, PD2);
                ListLine.Add(Dline);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_SIZE : GH_Component
    {

        public GET_RAM_COL_SIZE() : base("GET_RAM_COL_SIZE", "GRCS", "Get RAM Column Size", "RAM", "Column")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("B3F43701-3D84-4113-97A5-BC55C8D25FDB"); }
        }
        public static GET_RAM_COL_SIZE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<string> ListLine = new List<string>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                string My_Column_Size = My_Story.GetColumns().GetAt(i).strSectionLabel;
                ListLine.Add(My_Column_Size);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_ID : GH_Component
    {

        public GET_RAM_COL_ID() : base("GET_RAM_COL_ID", "GRCId", "Get RAM Column ID", "RAM", "Column")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("6120FAC6-E4E9-4DF7-A941-2D3B22294659"); }
        }
        public static GET_RAM_COL_ID Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                int My_Column_ID = My_Story.GetColumns().GetAt(i).lUID;
                ListLine.Add(My_Column_ID);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_Number : GH_Component
    {

        public GET_RAM_COL_Number() : base("GET_RAM_COL_Number", "GRCN", "Get RAM Column Number", "RAM", "Column")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("0164E389-0C5D-4009-813D-746D2C94EBB1"); }
        }
        public static GET_RAM_COL_Number Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("ColumnNumber", "CN", "Column Number", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                int My_Column_ID = My_Story.GetColumns().GetAt(i).lLabel; ;
                ListLine.Add(My_Column_ID);
            }
            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetData("ColumnNumber", ListLine);
        }
    }


    public class GET_RAM_COL_IS_GRAV_OR_LATERAL : GH_Component
    {

        public GET_RAM_COL_IS_GRAV_OR_LATERAL() : base("GET_RAM_COL_IS_GRAV_OR_LATERAL", "GRCIGOL", "Get RAM Column is Grav or Lateral", "RAM", "Column")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("97D69572-18E6-457C-B148-9C49F6E4A05A"); }
        }
        public static GET_RAM_COL_IS_GRAV_OR_LATERAL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("GravOrLateral", "GorL", "Grav or Lateral", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<string> ListLine = new List<string>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                string My_Column_EFrameType = My_Story.GetColumns().GetAt(i).eFramingType.ToString();
                ListLine.Add(My_Column_EFrameType);
            }
            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetData("GravOrLateral", ListLine);
        }
    }


    public class CREATE_RAM_STEEL_COL : GH_Component
    {

        public CREATE_RAM_STEEL_COL() : base("CREATE_RAM_STEEL_COL", "CRSC", "Create RAM Steel Column", "RAM", "Column")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("BBD9931B-EC6D-4CB9-BA3F-C494A0609DCC"); }
        }
        public static CREATE_RAM_STEEL_COL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("FloorIndex", "FI", "Floor Index", GH_ParamAccess.item);
            pManager.AddNumberParameter("XX", "XX", "XX", GH_ParamAccess.item);
            pManager.AddNumberParameter("YY", "YY", "YY", GH_ParamAccess.item);
            pManager.AddNumberParameter("ZTop", "ZT", "Z Top", GH_ParamAccess.item);
            pManager.AddNumberParameter("ZBot", "ZB", "Z Bottom", GH_ParamAccess.item);
            //int FloorIndex, string FileName, double XX, double YY, double ZTop, double ZBot
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("ColumnID", "CID", "Column ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int FloorIndex = 0;
            double XX = 0.0;
            double YY = 0.0;
            double ZTop = 0.0;
            double ZBot = 0.0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("FloorIndex", ref FloorIndex))
            {
                return;
            }
            if (FloorIndex == 0)
            {
                return;
            }
            if (!DA.GetData("XX", ref XX))
            {
                return;
            }
            if (!DA.GetData("YY", ref YY))
            {
                return;
            }
            if (!DA.GetData("ZTop", ref ZTop))
            {
                return;
            }
            if (!DA.GetData("ZBot", ref ZBot))
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_ColMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutColumn My_LayoutColumn = My_floortype.GetLayoutColumns().Add(My_ColMaterial, XX, YY, ZTop, ZBot);

            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Col_ID = My_LayoutColumn.lUID;
            DA.SetData("ColumnID", My_New_Col_ID);
        }
    }


    public class GET_RAM_BM_CL : GH_Component
    {

        public GET_RAM_BM_CL() : base("GET_RAM_BM_CL", "GRBCL", "Get RAM Beam ", "RAM", "Beam")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("A92B2F96-8CB0-46FE-A82A-F2580C507136"); }
        }
        public static GET_RAM_BM_CL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("BeamCoordinateList", "BCL", "Beam Coordinate List", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            SCoordinate P1 = new SCoordinate();
            SCoordinate P2 = new SCoordinate();
            List<Rhino.Geometry.Line> ListLine = new List<Rhino.Geometry.Line>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                My_Story.GetBeams().GetAt(i).GetCoordinates(EBeamCoordLoc.eBeamEnds, ref P1, ref P2);

                double P1x = P1.dXLoc;
                double P1y = P1.dYLoc;
                double P1z = P1.dZLoc;
                double P2x = P2.dXLoc;
                double P2y = P2.dYLoc;
                double P2z = P2.dZLoc;
                Rhino.Geometry.Point3d PD1 =
                        new Rhino.Geometry.Point3d(P1x, P1y, P1z);
                Rhino.Geometry.Point3d PD2 =
                        new Rhino.Geometry.Point3d(P2x, P2y, P2z);
                Rhino.Geometry.Line Dline =
                        new Rhino.Geometry.Line(PD1, PD2);
                ListLine.Add(Dline);
            }
            //CLOSE       
            IDBI.CloseDatabase();
            DA.SetData("BeamCoordinateList", ListLine);
        }
    }


    public class GET_RAM_BM_SIZE : GH_Component
    {

        public GET_RAM_BM_SIZE() : base("GET_RAM_BM_SIZE", "GRBS", "Get RAM Beam Size", "RAM", "Beam")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("CB18D58F-21E1-4E45-B4D3-A3F1C7EDB367"); }
        }
        public static GET_RAM_BM_SIZE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("BeamSize", "BS", "Beam Size", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<string> ListLine = new List<string>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                string My_Beam_Size = My_Story.GetBeams().GetAt(i).strSectionLabel;
                ListLine.Add(My_Beam_Size);
            }
            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetData("BeamSize", ListLine);
        }
    }

    public class GET_RAM_BM_id : GH_Component
    {

        public GET_RAM_BM_id() : base("GET_RAM_BM_id", "GRBId", "Get RAM Beam ID", "RAM", "Beam")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("49B511EF-E5F1-4155-89F4-EBB2D1D321E6"); }
        }
        public static GET_RAM_BM_id Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("BeamIDs", "BIDs", "Beam IDs", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                int My_Beam_ID = My_Story.GetBeams().GetAt(i).lUID;
                ListLine.Add(My_Beam_ID);
            }
            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetData("BeamIDs", ListLine);
        }
    }

    public class GET_RAM_BM_Number : GH_Component
    {

        public GET_RAM_BM_Number() : base("GET_RAM_BM_Number", "GRBNo", "Get RAM Beam Number", "RAM", "Beam")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("872176A8-F602-47B4-B8BD-1A4A70FB71B2"); }
        }
        public static GET_RAM_BM_Number Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("BeamNumbers", "BN", "Beam Numbers", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                int My_Beam_ID = My_Story.GetBeams().GetAt(i).lLabel;
                ListLine.Add(My_Beam_ID);
            }
            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetData("BeamNumbers", ListLine);
        }
    }

    public class GET_RAM_BM_GRAV_OR_LATERAL : GH_Component
    {

        public GET_RAM_BM_GRAV_OR_LATERAL() : base("GET_RAM_BM_GRAV_OR_LATERAL", "GRBGOL", "Get RAM Beam Grav or Lateral", "RAM", "Beam")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("0E64A4EE-6316-4634-B4E1-84CE2FAB7348"); }
        }
        public static GET_RAM_BM_GRAV_OR_LATERAL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            //TODO: Ensure List type for output is correct for EFRAMETYPE
            pManager.AddNumberParameter("GravOrLateral", "GorL", "Grav or Lateral", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<EFRAMETYPE> ListLine = new List<EFRAMETYPE>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                EFRAMETYPE My_Beam_EFrameType = My_Story.GetBeams().GetAt(i).eFramingType;
                ListLine.Add(My_Beam_EFrameType);
            }
            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetDataList("GravOrLateral", ListLine);
        }
    }


    public class CREATE_RAM_STEEL_BM : GH_Component
    {

        public CREATE_RAM_STEEL_BM() : base("CREATE_RAM_STEEL_BM", "CRSB", "Create RAM Steel Beam", "RAM", "Beam")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("FABB75A0-357A-4519-A544-2CFA298FC5D8"); }
        }
        public static CREATE_RAM_STEEL_BM Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("FloorIndex", "FI", "Floor Index", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportX", "SSX", "Start Support X", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportY", "SSY", "Start Support Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportZ", "SSZ", "Start Support Z", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportX", "ESX", "End Support X", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportY", "ESY", "End Support Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportX", "ESZ", "End Support Z", GH_ParamAccess.item);
            //int FloorIndex, string FileName, double StartSupportX, double StartSupportY,
            //double StartSupportZ, double EndSupportX, double EndSupportY, double EndSupportZ
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("BeamID", "BId", "Beam ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int FloorIndex= 0;
            double StartSupportX = 0.0;
            double StartSupportY = 0.0;
            double StartSupportZ = 0.0;
            double EndSupportX = 0.0;
            double EndSupportY = 0.0;
            double EndSupportZ = 0.0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("FloorIndex", ref FloorIndex))
            {
                return;
            }
            if (FloorIndex == 0)
            {
                return;
            }
            if (!DA.GetData("StartSupportX", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("StartSupportY", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("StartSupportZ", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("EndSupportX", ref EndSupportX))
            {
                return;
            }
            if (!DA.GetData("EndSupportY", ref EndSupportY))
            {
                return;
            }
            if (!DA.GetData("EndSupportZ", ref EndSupportZ))
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_BmMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutBeam My_LayoutBeam = My_floortype.GetLayoutBeams().Add(My_BmMaterial, StartSupportX, StartSupportY,
                StartSupportZ, EndSupportX, EndSupportY, EndSupportZ);

            int My_New_Beam_ID = My_LayoutBeam.lUID;

            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            DA.SetData("BeamID", My_New_Beam_ID);
        }
    }


    public class CREATE_RAM_STEEL_BRACE : GH_Component
    {

        public CREATE_RAM_STEEL_BRACE() : base("CREATE_RAM_STEEL_BRACE", "CRSB", "Create RAM Steel Brace", "RAM", "Brace")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("70990BB1-13DC-459D-9E07-5EA26CADCFE7"); }
        }
        public static CREATE_RAM_STEEL_BRACE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("FloorIndex", "FI", "Floor Index", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportX", "SSX", "Start Support X", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportY", "SSY", "Start Support Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportZ", "SSZ", "Start Support Z", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportX", "ESX", "End Support X", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportY", "ESY", "End Support Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportX", "ESZ", "End Support Z", GH_ParamAccess.item);
            //int FloorIndex, string FileName, double StartSupportX, double StartSupportY,
            //double StartSupportZ, double EndSupportX, double EndSupportY, double EndSupportZ

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("BraceID", "BId", "Brace ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int FloorIndex = 0;
            double StartSupportX = 0.0;
            double StartSupportY = 0.0;
            double StartSupportZ = 0.0;
            double EndSupportX = 0.0;
            double EndSupportY = 0.0;
            double EndSupportZ = 0.0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("FloorIndex", ref FloorIndex))
            {
                return;
            }
            if (FloorIndex == 0)
            {
                return;
            }
            if (!DA.GetData("StartSupportX", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("StartSupportY", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("StartSupportZ", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("EndSupportX", ref EndSupportX))
            {
                return;
            }
            if (!DA.GetData("EndSupportY", ref EndSupportY))
            {
                return;
            }
            if (!DA.GetData("EndSupportZ", ref EndSupportZ))
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_BmMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutHorizBrace My_LayoutBrace = My_floortype.GetLayoutHorizBraces().Add(My_BmMaterial,
                StartSupportX, StartSupportY,
                StartSupportZ, EndSupportX, EndSupportY, EndSupportZ);

            int My_New_Brace_ID = My_LayoutBrace.lUID;
            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            DA.SetData("BraceID", My_New_Brace_ID);
        }
    }


    public class CREATE_RAM_STEEL_HORZ_BRACE : GH_Component
    {

        public CREATE_RAM_STEEL_HORZ_BRACE() : base("CREATE_RAM_STEEL_HORZ_BRACE", "CRSHB", "Create RAM Steel Horizontal Brace", "RAM", "Brace")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("F1B9863D-8EC1-4BF1-B91F-64EAF8E73259"); }
        }
        public static CREATE_RAM_STEEL_HORZ_BRACE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("FloorIndex", "FI", "Floor Index", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportX", "SSX", "Start Support X", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportY", "SSY", "Start Support Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("StartSupportZ", "SSZ", "Start Support Z", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportX", "ESX", "End Support X", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportY", "ESY", "End Support Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("EndSupportX", "ESZ", "End Support Z", GH_ParamAccess.item);
            //int FloorIndex, string FileName, double StartSupportX, double StartSupportY,
            //double StartSupportZ, double EndSupportX, double EndSupportY, double EndSupportZ

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("BraceID", "BId", "Brace ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int FloorIndex = 0;
            double StartSupportX = 0.0;
            double StartSupportY = 0.0;
            double StartSupportZ = 0.0;
            double EndSupportX = 0.0;
            double EndSupportY = 0.0;
            double EndSupportZ = 0.0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("FloorIndex", ref FloorIndex))
            {
                return;
            }
            if (FloorIndex == 0)
            {
                return;
            }
            if (!DA.GetData("StartSupportX", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("StartSupportY", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("StartSupportZ", ref StartSupportX))
            {
                return;
            }
            if (!DA.GetData("EndSupportX", ref EndSupportX))
            {
                return;
            }
            if (!DA.GetData("EndSupportY", ref EndSupportY))
            {
                return;
            }
            if (!DA.GetData("EndSupportZ", ref EndSupportZ))
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_BmMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutHorizBrace My_LayoutBrace = My_floortype.GetLayoutHorizBraces().Add(My_BmMaterial,
                StartSupportX, StartSupportY,
                StartSupportZ, EndSupportX, EndSupportY, EndSupportZ);

            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Brace_ID = My_LayoutBrace.lUID;
            DA.SetData("BraceID", My_New_Brace_ID);
        }
    }

    public class CREATE_RAM_STEEL_VERT_BRACE : GH_Component
    {

        public CREATE_RAM_STEEL_VERT_BRACE() : base("CREATE_RAM_STEEL_VERT_BRACE", "CRSVB", "Create RAM Steel Vertical Brace", "RAM", "Brace")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("D6B9323C-09E9-442E-9B4F-EC647E25DD5C"); }
        }
        public static CREATE_RAM_STEEL_VERT_BRACE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("StoryID", "SId", "Story ID", GH_ParamAccess.item);
            pManager.AddNumberParameter("TopStoryID", "TSID", "Top Story ID", GH_ParamAccess.item);
            pManager.AddNumberParameter("TopX", "TX", "Top X", GH_ParamAccess.item);
            pManager.AddNumberParameter("TopY", "TY", "Top Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("TopZ", "TZ", "Top Z", GH_ParamAccess.item);
            pManager.AddNumberParameter("BotStoryID", "BSID", "Bottom Story ID", GH_ParamAccess.item);
            pManager.AddNumberParameter("BotX", "BX", "Bottom X", GH_ParamAccess.item);
            pManager.AddNumberParameter("BotY", "BY", "Bottom Y", GH_ParamAccess.item);
            pManager.AddNumberParameter("BotZ", "BZ", "Bottom Z", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("VertBraceID", "VBID", "Vertical Brace ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int StoryID = 0;
            int TopStoryID = 0;
            int BotStoryID = 0;
            double TopX = 0.0;
            double TopY = 0.0;
            double TopZ = 0.0;
            double BotX = 0.0;
            double BotY = 0.0;
            double BotZ = 0.0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("StoryID", ref StoryID))
            {
                return;
            }
            if (StoryID == 0)
            {
                return;
            }
            if (!DA.GetData("TopStoryID", ref TopStoryID))
            {
                return;
            }
            if (StoryID == 0)
            {
                return;
            }
            if (!DA.GetData("BotStoryID", ref BotStoryID))
            {
                return;
            }
            if (StoryID == 0)
            {
                return;
            }
            if (!DA.GetData("TopX", ref TopX))
            {
                return;
            }
            if (!DA.GetData("TopY", ref TopX))
            {
                return;
            }
            if (!DA.GetData("TopZ", ref TopX))
            {
                return;
            }
            if (!DA.GetData("BotX", ref BotX))
            {
                return;
            }
            if (!DA.GetData("BotY", ref BotY))
            {
                return;
            }
            if (!DA.GetData("BotZ", ref BotZ))
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IStories My_storytypes = IModel.GetStories();
            IStory My_storytype = My_storytypes.Get(StoryID);
            EMATERIALTYPES My_BmMaterial = EMATERIALTYPES.ESteelMat;

            IVerticalBraces My_VertBraces = My_storytype.GetVerticalBraces();
            IVerticalBrace My_VertBrace = My_VertBraces.Add(My_BmMaterial, TopStoryID, TopX, TopY, TopZ, BotStoryID, BotX, BotY, BotZ);
            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Brace_ID = My_VertBrace.lUID;
            DA.SetData("VertBraceID", My_New_Brace_ID);
        }
    }

    public class GET_GRID_INFO : GH_Component
    {

        public GET_GRID_INFO() : base("GET_GRID_INFO", "GGI", "Get Grid Info", "RAM", "Grid")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("53DA9F9B-A064-4EB9-A436-3613C57A640F"); }
        }
        public static GET_GRID_INFO Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("GridName", "GN", "Grid Name", GH_ParamAccess.list);
            pManager.AddNumberParameter("GridOrdinates", "GO", "Grid Ordinates", GH_ParamAccess.list);
            pManager.AddTextParameter("GridAxis", "GA", "Grid Axis", GH_ParamAccess.list);

            //Outputs Dictionary type
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            Dictionary<string, object> OutPutPorts = new Dictionary<string, object>();
            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IModelGrids My_Model_Grids = IModel.GetGridSystems().GetAt(0).GetGrids();
            int My_Grid_Count = My_Model_Grids.GetCount();
            List<double> Grid_Ordinates = new List<double>();
            List<string> Grid_Name = new List<string>();
            List<string> Grid_Axis = new List<string>();

            for (int i = 0; i < My_Grid_Count; i = i + 1)
            {
                //round up and convert grids from inches to feet
                double My_Grid_ORD = Math.Ceiling(My_Model_Grids.GetAt(i).dCoordinate_Angle / 12);
                string My_Model_Grid_Names = My_Model_Grids.GetAt(i).strLabel;
                string My_Model_Grid_Axis = My_Model_Grids.GetAt(i).eAxis.ToString();
                string My_String_Cleanup1 = My_Model_Grid_Axis.Remove(0, 5);
                string My_String_Cleanup2 = My_String_Cleanup1.Remove(1);
                Grid_Ordinates.Add(My_Grid_ORD);
                Grid_Name.Add(My_Model_Grid_Names);
                Grid_Axis.Add(My_String_Cleanup2);
            }
            DA.SetData("GridName", Grid_Name);
            DA.SetData("GridOrdinates", Grid_Ordinates);
            DA.SetData("GridAxis", Grid_Axis);
            //CLOSE 

            IDBI.CloseDatabase();
        }
    }


    public class CREATE_GRIDS : GH_Component
    {

        public CREATE_GRIDS() : base("CREATE_GRIDS", "CG", "Create Grids", "RAM", "Grid")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("494C575A-5A6D-4192-ABC0-B75ED0BA14F5"); }
        }
        public static CREATE_GRIDS Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddTextParameter("XGridLabel", "XGL", "X Grid Label", GH_ParamAccess.item);
            pManager.AddNumberParameter("XGridCoord", "XGC", "X Grid Coordinate", GH_ParamAccess.item);
            pManager.AddTextParameter("YGridLabel", "YGL", "Y Grid Label", GH_ParamAccess.item);
            pManager.AddNumberParameter("YGridCoord", "YGC", "Y Grid Coordinate", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("XGridID", "XGId", "New X Grid ID", GH_ParamAccess.item);
            pManager.AddNumberParameter("YGridID", "YGId", "New Y Grid ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            Dictionary<string, object> OutPutPorts = new Dictionary<string, object>();
            //OPEN
            string FileName = null;
            string XGridLabel = null;
            string YGridLabel = null;
            double XGridCoord = 0.0;
            double YGridCoord = 0.0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("XGridLabel", ref XGridLabel))
            {
                return;
            }
            if (XGridLabel == null || XGridLabel.Length == 0)
            {
                return;
            }
            if (!DA.GetData("YGridLabel", ref YGridLabel))
            {
                return;
            }
            if (YGridLabel == null || YGridLabel.Length == 0)
            {
                return;
            }
            if (!DA.GetData("XGridCoord", ref XGridCoord))
            {
                return;
            }
            if (!DA.GetData("YGridCoord", ref YGridCoord))
            {
                return;
            }

            IDBI.LoadDataBase2(FileName, "1");
            IModelGrids My_Model_Grids = IModel.GetGridSystems().GetAt(0).GetGrids();
            //CONVERT TO FEET BY *12 ON INPUT GRID COORDINATE
            IModelGrid MyXIModelGrid = My_Model_Grids.Add(XGridLabel, 
                EGridAxis.eGridXorRadialAxis, XGridCoord*12);
            IModelGrid MyYIModelGrid = My_Model_Grids.Add(YGridLabel, 
                EGridAxis.eGridYorCircularAxis, YGridCoord * 12);
            int My_NewXIModelGridID = MyXIModelGrid.lUID;
            int My_NewYIModelGridID = MyYIModelGrid.lUID;

            DA.SetData("XGridID", My_NewXIModelGridID);
            DA.SetData("YGridID", My_NewYIModelGridID);
            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
        }
    }


    public class GET_NUM_LOAD_CASES : GH_Component
    {

        public GET_NUM_LOAD_CASES() : base("GET_NUM_LOAD_CASES", "GNLC", "Get Number of Load Cases", "RAM", "Load")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("7560EDB0-D3CF-4982-A971-FA2375C83E09"); }
        }
        public static GET_NUM_LOAD_CASES Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("NumLoadCases", "NLC", "Number of Load Cases", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            RAMDATAACCESSLib.IForces2 IForces2 = (RAMDATAACCESSLib.IForces2)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IForces2_INT);

            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            EAnalysisResultType My_EAnalysisResultType = EAnalysisResultType.DefaultResultType;
            int plNumAnalysisCases = 0;

            //these methods work when accessing IFORCES2 so accessing IFORCES2 correctly?
            Type MyIForces2_Type = IForces2.GetType();
            int MyIforces2_Hashcode = IForces2.GetHashCode();
            IForces2.GetNumAnalysisCases(My_EAnalysisResultType, ref plNumAnalysisCases);

            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetData("NumLoadCases", plNumAnalysisCases);
        }
    }


    public class GET_GRV_COL_FORCES : GH_Component
    {

        public GET_GRV_COL_FORCES() : base("GET_GRV_COL_FORCES", "GGCF", "Get Gravity Colum Forces", "RAM", "Column")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("C841197D-10B1-4C6C-999B-DBE66A19EB71"); }
        }
        public static GET_GRV_COL_FORCES Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("ColumnID", "CId", "Column ID", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("DeadLoad", "DL", "Dead Load", GH_ParamAccess.list);
            pManager.AddNumberParameter("PosLLRed", "PLLR", "Positive Live Load Red", GH_ParamAccess.list);
            pManager.AddNumberParameter("PosLLNonRed", "PLLNR", "Positive Live Load Non Red", GH_ParamAccess.list);
            pManager.AddNumberParameter("PosLLStorage", "PLLS", "Positive Live Load Storage", GH_ParamAccess.list);
            pManager.AddNumberParameter("PosLLRoof", "PLLR", "Positive Live Load Roof", GH_ParamAccess.list);
            pManager.AddNumberParameter("NegLLRed", "NLLR", "Negative Live Load Red", GH_ParamAccess.list);
            pManager.AddNumberParameter("NegLLNonRed", "NLLNR", "Negative Live Load Non Red", GH_ParamAccess.list);
            pManager.AddNumberParameter("NegLLStorage", "NLLS", "Negative Live Load Storage", GH_ParamAccess.list);
            pManager.AddNumberParameter("NegLLRoof", "NLLR", "Negative Live Load Roof", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            RAMDATAACCESSLib.IForces1 IForces1 = (RAMDATAACCESSLib.IForces1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IForces_INT);
            //OPEN
            string FileName = null;
            int ColumnID = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("ColumnID", ref ColumnID))
            {
                return;
            }
            if (ColumnID == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            double pdDead = 0;
            double pdPosLLRed = 0;
            double pdPosLLNonRed = 0;
            double pdPosLLStorage = 0;
            double pdPosLLRoof = 0;
            double pdNegLLRed = 0;
            double pdNegLLNonRed = 0;
            double pdNegLLStorage = 0;
            double pdNegLLRoof = 0;
            IForces1.GetGrvColForcesForLCase(ColumnID, ref pdDead, ref pdPosLLRed,
                ref pdPosLLNonRed, ref pdPosLLStorage, ref pdPosLLRoof, ref pdNegLLRed,
                ref pdNegLLNonRed, ref pdNegLLStorage, ref pdNegLLRoof);
            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            int My_floortype_count = My_floortypes.GetCount();
            //CLOSE           
            IDBI.CloseDatabase();
            DA.SetData("pdDead", pdDead); 
            DA.SetData("pdPosLLRed", pdPosLLRed);
            DA.SetData("pdPosLLNonRed", pdPosLLNonRed); 
            DA.SetData("pdPosLLStorage", pdPosLLStorage);
            DA.SetData("pdPosLLRoof", pdPosLLRoof); 
            DA.SetData("pdNegLLRed", pdNegLLRed);
            DA.SetData("pdNegLLNonRed", pdNegLLNonRed); 
            DA.SetData("pdNegLLStorage", pdNegLLStorage);
            DA.SetData("pdNegLLRoof", pdNegLLRoof);
        }
    }


    public class CREATE_FLOOR_TYPE : GH_Component
    {

        public CREATE_FLOOR_TYPE() : base("CREATE_FLOOR_TYPE", "CFT", "Create Floor Type", "RAM", "Floor")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("7673A797-439F-4D15-9B59-F048911135B4"); }
        }
        public static CREATE_FLOOR_TYPE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddTextParameter("FloorTypeName", "FTN", "Floor Type Name", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddLineParameter("FloorTypeIDs", "FTIDs", "Floor Type IDs", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            string FileName = null;
            string FloorTypeName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("FloorTypeName", ref FloorTypeName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_New_floortype = My_floortypes.Add(FloorTypeName);
            int MyFlrTypeID = My_New_floortype.lUID;

            //CLOSE
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();

            DA.SetData("FloorTypeIDs", MyFlrTypeID);
        }
    }


    public class GET_STORY_IDS : GH_Component
    {

        public GET_STORY_IDS() : base("GET_STORY_IDS", "GSIds", "Get Story IDs", "RAM", "Story")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("F6E9374F-D46A-47AD-ADBD-4600EEC7FC03"); }
        }
        public static GET_STORY_IDS Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            //TODO: Ensure List type for output is correct for EFRAMETYPE
            pManager.AddNumberParameter("StoryIDs", "SIds", "Story IDs", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int Story_Count = My_stories.GetCount();
            List<int> ListLine = new List<int>();
            for (int i = 0; i < Story_Count; i = i + 1)
            {
                int My_Story_Id = My_stories.GetAt(i).lUID;
                ListLine.Add(My_Story_Id);
            }
            //CLOSE
            DA.SetData("StoryIDs", ListLine);
            IDBI.CloseDatabase();
        }
    }


    public class GET_STORY_NAMES : GH_Component
    {

        public GET_STORY_NAMES() : base("GET_STORY_NAMES", "GSN", "Get Story Names", "RAM", "Story")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("A47CE45F-4C7D-4BD3-B013-E4412ACCE731"); }
        }
        public static GET_STORY_NAMES Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            //TODO: Ensure List type for output is correct for EFRAMETYPE
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int Story_Count = My_stories.GetCount();
            List<string> ListLine = new List<string>();
            for (int i = 0; i < Story_Count; i = i + 1)
            {
                string My_Story_Names = My_stories.GetAt(i).strLabel;
                ListLine.Add(My_Story_Names);
            }
            //CLOSE
            DA.SetData("ListLine", ListLine);
            IDBI.CloseDatabase();
        }
    }


    public class GET_GRIDS_AT_COL : GH_Component
    {

        public GET_GRIDS_AT_COL() : base("GET_GRIDS_AT_COL", "GGatC", "Get Grids at Column", "RAM", "Grid")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("F7E98124-695E-4977-8B3D-613D38F7EFFC"); }
        }
        public static GET_GRIDS_AT_COL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("StartPoints", "SP", "Start Points", GH_ParamAccess.list);
            pManager.AddPointParameter("EndPoints", "EP", "End Points", GH_ParamAccess.list);
            pManager.AddTextParameter("ColumnSizes", "CS", "Column Sizes", GH_ParamAccess.list);
            pManager.AddNumberParameter("ColumnNumbers", "CN", "Column Numbers", GH_ParamAccess.list);
            pManager.AddLineParameter("ColumnLines", "CL", "Column Lines", GH_ParamAccess.list);
            pManager.AddNumberParameter("XGrids", "XG", "X Grids", GH_ParamAccess.list);
            pManager.AddNumberParameter("YGrids", "YG", "Y Grids", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDB = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            RAMDATAACCESSLib.IModelGeometry1 IModelGeo = (RAMDATAACCESSLib.IModelGeometry1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModelGeometry_INT);

            RAMDATAACCESSLib.IMemberData1 IModelMembers = (RAMDATAACCESSLib.IMemberData1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IMemberData_INT);

            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            LoadRSS(FileName, IDB);

            Dictionary<string, object> ReturnValues = new Dictionary<string, object>();

            List<Rhino.Geometry.Point3d> StartPoints = new List<Rhino.Geometry.Point3d>();
            List<Rhino.Geometry.Point3d> EndPoints = new List<Rhino.Geometry.Point3d>();
            List<int> ColNums = new List<int>();
            List<string> ColSizes = new List<string>();
            List<Rhino.Geometry.Line> AllOutLines = new List<Rhino.Geometry.Line>();
            List<string> XGrids = new List<string>();
            List<string> YGrids = new List<string>();

            try
            {
                int NumfloorTypes = 0;

                //IModel.GetFloorTypes().GetAt(1);

                IModelGeo.GetNumStories(ref NumfloorTypes);


                IStories AllStories = IModel.GetStories();
                int Numstories = AllStories.GetCount();

                for (int i = 0; i < Numstories; i++)
                {
                    IStory Story1 = AllStories.GetAt(i);

                    IColumns AllCols = Story1.GetColumns();
                    int NumCols = AllCols.GetCount();

                    IFloorType ThisFloorType = Story1.GetFloorType();


                    IGridSystem MatchingGridSystem;
                    object OutItem = -1;

                    var GridSystems = ThisFloorType.GetGridSystemIDArray();
                    GridSystems.GetAt(0, ref OutItem);
                    MatchingGridSystem = IModel.GetGridSystem((int)OutItem);

                    for (int j = 0; j < NumCols; j++)
                    {
                        IColumn Col1 = AllCols.GetAt(j);

                        int ID = Col1.lUID;


                        SCoordinate P1 = new SCoordinate();
                        SCoordinate P2 = new SCoordinate();

                        int retVal = Col1.GetEndCoordinates(ref P1, ref P2);

                        Rhino.Geometry.Point3d StartPoint = new Rhino.Geometry.Point3d(P1.dXLoc, P1.dYLoc, P1.dZLoc);
                        Rhino.Geometry.Point3d EndPoint = new Rhino.Geometry.Point3d(P2.dXLoc, P2.dYLoc, P2.dZLoc);

                        string ColLabel = Col1.strSectionLabel;

                        Rhino.Geometry.Line NewLine = new Rhino.Geometry.Line(StartPoint, EndPoint);

                        string XGrid;
                        string YGrid;

                        GetPointGridLoc(MatchingGridSystem, P1.dXLoc, P1.dYLoc, out XGrid, out YGrid);

                        ColNums.Add(Col1.lLabel);

                        XGrids.Add(XGrid);
                        YGrids.Add(YGrid);



                    }
                }

                DA.SetData("ColumnNumbers", ColNums);
                DA.SetData("StartPoints", StartPoints);
                DA.SetData("EndPoints", EndPoints);
                DA.SetData("ColumnLines", AllOutLines);
                DA.SetData("ColumnSize", ColSizes);
                DA.SetData("XGrids", XGrids);
                DA.SetData("YGrids", YGrids);

            }
            catch (Exception ex)
            {

                throw(ex);
            }
            finally
            {
                IDB.CloseDatabase();

                IModelGeo = null;
                IDB = null;
                RAMDataAccess = null;

            }

        }

        private static void LoadRSS(string Filename, RAMDATAACCESSLib.IDBIO1 IDB)
        {

            int LoadStatus = IDB.LoadDataBase2(Filename, "1");

            if (LoadStatus != 0)
            {
                //First try and delete the tempfile in the same directory
                string BUFilename = Filename.Remove(Filename.Length - 3) + "usr";
                try
                {
                    File.Delete(BUFilename);
                }
                catch
                {

                }

                //Also, try and delete the tempfile directory
                //string WorkingDir = @"C:\ProgramData\Bentley\Engineering\RAM Structural System\Working\";
                string ProgramDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string WorkingDir = ProgramDataFolder + @"\Bentley\Engineering\RAM Structural System\Working\";


                //string JustFileName = Filename.Substring(Filename.LastIndexOf("\\") + 1);

                System.IO.DirectoryInfo di = new DirectoryInfo(WorkingDir);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                //Ok, try 2
                LoadStatus = IDB.LoadDataBase2(Filename, "1");

                if (LoadStatus != 0)
                {
                    throw new ArgumentException("Could not load file " + Filename);
                }

            }

        }

        /// <summary>
        /// Gets grid coordinates given a grid system and a point
        /// </summary>
        /// <param name="MatchingGridSystem"></param>
        /// <param name="XLoc"></param>
        /// <param name="YLoc"></param>
        /// <param name="XGrid"></param>
        /// <param name="YGrid"></param>
        private static void GetPointGridLoc(IGridSystem MatchingGridSystem, double XLoc, double YLoc, out string XGrid, out string YGrid)
        {
            IModelGrids ModelGrids = MatchingGridSystem.GetGrids();

            int NumGrids = ModelGrids.GetCount();

            XGrid = "";
            YGrid = "";

            for (int k = 0; k < NumGrids; k++)
            {
                IModelGrid TestGrid = ModelGrids.GetAt(k);
                EGridAxis GridAxis = TestGrid.eAxis;

                double GridValue = TestGrid.dCoordinate_Angle;

                if (GridAxis == EGridAxis.eGridXorRadialAxis)
                {
                    if (GridValue - XLoc < 0.0001)
                    {
                        XGrid = TestGrid.strLabel;
                    }

                }
                else if (GridAxis == EGridAxis.eGridYorCircularAxis)
                {
                    if (GridValue - YLoc < 0.0001)
                    {
                        YGrid = TestGrid.strLabel;
                    }

                }
            }
        }


        internal static int GetStoryIDFromName(RAMDATAACCESSLib.IModel IModel, string StoryName)
        {
            IStories My_stories = IModel.GetStories();
            int Story_Count = My_stories.GetCount();

            for (int i = 0; i < Story_Count; i = i + 1)
            {
                IStory MatchedStory = My_stories.GetAt(i);

                if (MatchedStory.strLabel == StoryName)
                {
                    return MatchedStory.lUID;
                }
            }

            throw new ArgumentException("Could not find a story named " + StoryName);
        }
    }


    public class GET_RAM_BM_STUD_CAMBER_MRatio : GH_Component
    {

        public GET_RAM_BM_STUD_CAMBER_MRatio() : base("GET_RAM_BM_STUD_CAMBER_MRatio", "GRBSCMR", "Get RAM Beam Stud Camber MRatio", "RAM", "Beam")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("8394805E-3430-4524-8FA0-9AC344C4E309"); }
        }
        public static GET_RAM_BM_STUD_CAMBER_MRatio Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("StoryID", "CId", "Column ID", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("GravityBeamIDs", "GBIds", "Gravity Beam IDs", GH_ParamAccess.item);
            pManager.AddNumberParameter("GravityBeamNums", "GBNs", "Gravity Beam Nums", GH_ParamAccess.item);
            pManager.AddNumberParameter("Camber", "C", "Camber", GH_ParamAccess.item);
            pManager.AddNumberParameter("TotalNumStuds", "TNSs", "Total Number of Studs", GH_ParamAccess.item);
            pManager.AddNumberParameter("StrengthRatios", "SRs", "Strength Ratios", GH_ParamAccess.item);
            pManager.AddNumberParameter("DeflectionRatios", "DRs", "Deflection Ratios", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int StoryID = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("StoryID", ref StoryID))
            {
                return;
            }
            if (StoryID == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();

            IStory My_Story_BY_id = My_stories.Get(StoryID);

            List<double> Cambers = new List<double>();
            List<int> TotalNumsOfStuds = new List<int>();
            List<double> StrengthRatios = new List<double>();
            List<double> DeflectionRatios = new List<double>();
            List<int> BeamNums = new List<int>();
            List<int> BeamIDs = new List<int>();

            IBeams My_Beams = My_Story_BY_id.GetBeams();
            int Beam_Count = My_Beams.GetCount();

            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                IBeam My_Beam = My_Story_BY_id.GetBeams().GetAt(i);

                EFRAMETYPE My_Beam_EFrameType = My_Beam.eFramingType;

                if (My_Beam_EFrameType == EFRAMETYPE.MemberIsGravity)
                {

                    int SizeofArray = 0;
                    object ITEM = 1;
                    double Camber = My_Beam.dCamber;

                    DAArray My_Array_of_Studs = My_Beam.GetSteelDesignResult().GetNumStudsInSegments();
                    My_Array_of_Studs.GetSize(ref SizeofArray);

                    double My_Moment_DemandCapRatio = My_Beam.GetSteelDesignResult().dDesignCapacityInteraction;
                    double My_Deflection_DemandCapRatio = My_Beam.GetSteelDesignResult().dCriticalDeflectionInteraction;

                    List<int> ListLine = new List<int>();
                    //loop thru those studs in a segment and get them in a list then cast them from object to int to .sum it up....
                    for (int j = 0; j < SizeofArray; j = j + 1)
                    {
                        My_Array_of_Studs.GetAt(j, ref ITEM);
                        ListLine.Add((int)ITEM);
                    }
                    int TotalofStuds = ListLine.Sum();

                    BeamNums.Add(My_Beam.lLabel);
                    BeamIDs.Add(My_Beam.lUID);
                    Cambers.Add(Camber);
                    TotalNumsOfStuds.Add(TotalofStuds);
                    StrengthRatios.Add(Math.Round(My_Moment_DemandCapRatio, 2));
                    DeflectionRatios.Add(Math.Round(My_Deflection_DemandCapRatio, 2));
                }
            }


            DA.SetData("GravityBeamIDs", BeamIDs);
            DA.SetData("GravityBeamNums", BeamNums);
            DA.SetData("Camber", Cambers);
            DA.SetData("TotalNumStuds", TotalNumsOfStuds);
            //Round up results
            DA.SetData("StrengthRatios", StrengthRatios);
            DA.SetData("DeflectionRatios", DeflectionRatios);

            //CLOSE           
            IDBI.CloseDatabase();
        }
    }
}
