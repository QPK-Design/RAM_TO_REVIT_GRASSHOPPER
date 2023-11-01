using RAM_TO_REVIT_GRASSHOPPER;
using Grasshopper.Kernel;
using RAMDATAACCESSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RAM_TO_REVIT_GRASSHOPPER
{
    public class GET_FLOOR_TYPE_COUNT : GH_Component
    {

        public GET_FLOOR_TYPE_COUNT() : base("GET_FLOOR_TYPE_COUNT", "GFTC", "Get floor type count", "RAM", "Data")
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
            DA.SetData("FloorTypeCount", My_floortype_count);

            //CLOSE
            IDBI.CloseDatabase();
        }
    }

    public class GET_FLOOR_TYPE_IDS : GH_Component
    {

        public GET_FLOOR_TYPE_IDS() : base("GET_FLOOR_TYPE_IDS", "GFTIDs", "Get the floor type Identifiers", "RAM", "Data")
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
            DA.SetData("FloorTypeID", My_FloorType_ID);
            //  
            IDBI.CloseDatabase();
        }
    }


    public class SET_FLOOR_TYPE : GH_Component
    {

        public SET_FLOOR_TYPE() : base("SET_FLOOR_TYPE", "SFT", "Set Floor Type", "RAM", "Data")
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

        public GET_STORY_COUNT() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Data")
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

        public GET_RAM_COL_CL() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Data")
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

        public GET_RAM_COL_SIZE() : base("GET_RAM_COL_SIZE", "GRCS", "Get RAM Column Size", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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

        public GET_RAM_COL_ID() : base("GET_RAM_COL_ID", "GRCId", "Get RAM Column ID", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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

        public GET_RAM_COL_Number() : base("GET_RAM_COL_Number", "GRCN", "Get RAM Column Number", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
                int My_Column_ID = My_Story.GetColumns().GetAt(i).lLabel; ;
                ListLine.Add(My_Column_ID);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_IS_GRAV_OR_LATERAL : GH_Component
    {

        public GET_RAM_COL_IS_GRAV_OR_LATERAL() : base("GET_RAM_COL_IS_GRAV_OR_LATERAL", "GRCIGOL", "Get RAM Column is Grav or Lateral", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
                string My_Column_EFrameType = My_Story.GetColumns().GetAt(i).eFramingType.ToString();
                ListLine.Add(My_Column_EFrameType);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class CREATE_RAM_STEEL_COL : GH_Component
    {

        public CREATE_RAM_STEEL_COL() : base("CREATE_RAM_STEEL_COL", "CRSC", "Create RAM Steel Column", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
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
        }
    }


    public class GET_RAM_BM_CL : GH_Component
    {

        public GET_RAM_BM_CL() : base("GET_RAM_BM_CL", "GRBCL", "Get RAM Beam ", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
        }
    }


    public class GET_RAM_BM_SIZE : GH_Component
    {

        public GET_RAM_BM_SIZE() : base("GET_RAM_BM_SIZE", "GRBS", "Get RAM Beam Size", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
        }
    }

    public class GET_RAM_BM_id : GH_Component
    {

        public GET_RAM_BM_id() : base("GET_RAM_BM_id", "GRBId", "Get RAM Beam ID", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
        }
    }

    public class GET_RAM_BM_Number : GH_Component
    {

        public GET_RAM_BM_Number() : base("GET_RAM_BM_Number", "GRBNo", "Get RAM Beam Number", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
        }
    }

    public class GET_RAM_BM_GRAV_OR_LATERAL : GH_Component
    {

        public GET_RAM_BM_GRAV_OR_LATERAL() : base("GET_RAM_BM_GRAV_OR_LATERAL", "GRBGOL", "Get RAM Beam Grav or Lateral", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
        }
    }


    public class CREATE_RAM_STEEL_BM : GH_Component
    {

        public CREATE_RAM_STEEL_BM() : base("CREATE_RAM_STEEL_BM", "CRSB", "Create RAM Steel Beam", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
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

            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Beam_ID = My_LayoutBeam.lUID;
        }
    }


    public class CREATE_RAM_STEEL_BRACE : GH_Component
    {

        public CREATE_RAM_STEEL_BRACE() : base("CREATE_RAM_STEEL_BRACE", "CRSB", "Create RAM Steel Brace", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
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
        }
    }


    public class GET_GRID_INFO : GH_Component
    {

        public GET_GRID_INFO() : base("GET_GRID_INFO", "GGI", "Get Grid Info", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddTextParameter(, , , GH_ParamAccess.item);

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
            OutPutPorts.Add("Grid_Name", Grid_Name);
            OutPutPorts.Add("Grid_Ordinates", Grid_Ordinates);
            OutPutPorts.Add("Grid_Axis", Grid_Axis);
            //CLOSE 

            IDBI.CloseDatabase();
        }
    }


    public class CREATE_GRIDS : GH_Component
    {

        public CREATE_GRIDS() : base("CREATE_GRIDS", "CG", "Create Grids", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            //string FileName, string XGridLabel, double XGridCoord, string YGridLabel, double YGridCoord
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
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

            OutPutPorts.Add("NewXGrid(ID)", My_NewXIModelGridID);
            OutPutPorts.Add("NewYGrid(ID)", My_NewYIModelGridID);
            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
        }
    }


    public class GET_NUM_LOAD_CASES : GH_Component
    {

        public GET_NUM_LOAD_CASES() : base("GET_NUM_LOAD_CASES", "GNLC", "Get Number of Load Cases", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
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
        }
    }


    public class GET_GRV_COL_FORCES : GH_Component
    {

        public GET_GRV_COL_FORCES() : base("GET_GRV_COL_FORCES", "GGCF", "Get Gravity Colum Forces", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddLineParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
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
            Dictionary<string, object> OutPutPorts = new Dictionary<string, object>();
            //OPEN
            string FileName = null;
            int ColumnID= 0;
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
            OutPutPorts.Add("pdDead", pdDead); OutPutPorts.Add("pdPosLLRed", pdPosLLRed);
            OutPutPorts.Add("pdPosLLNonRed", pdPosLLNonRed); OutPutPorts.Add("pdPosLLStorage", pdPosLLStorage);
            OutPutPorts.Add("pdPosLLRoof", pdPosLLRoof); OutPutPorts.Add("pdNegLLRed", pdNegLLRed);
            OutPutPorts.Add("pdNegLLNonRed", pdNegLLNonRed); OutPutPorts.Add("pdNegLLStorage", pdNegLLStorage);
            OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
        }
    }


    public class CREATE_FLOOR_TYPE : GH_Component
    {

        public CREATE_FLOOR_TYPE() : base("CREATE_FLOOR_TYPE", "CFT", "Create Floor Type", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddLineParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
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

            DA.SetData("ListLine", MyFlrTypeID);
        }
    }


    public class GET_STORY_IDS : GH_Component
    {

        public GET_STORY_IDS() : base("GET_STORY_IDS", "GSIds", "Get Story IDs", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            pManager.AddLineParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
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
            IDBI.CloseDatabase();
        }
    }


    public class GET_STORY_NAMES : GH_Component
    {

        public GET_STORY_NAMES() : base("GET_STORY_NAMES", "GSN", "Get Story Names", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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

        public GET_GRIDS_AT_COL() : base("GET_GRIDS_AT_COL", "GGatC", "Get Grids at Column", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
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
            //TODO: Ensure List type for output is correct for multiple lists in SolveInstance
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
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

                ReturnValues.Add("ColumnNums", ColNums);
                //ReturnValues.Add("Column Start", StartPoints);
                //ReturnValues.Add("Column End", EndPoints);
                //ReturnValues.Add("Column Lines", AllOutLines);
                //ReturnValues.Add("Column Size", ColSizes);
                ReturnValues.Add("XGrids", XGrids);
                ReturnValues.Add("YGrids", YGrids);

                DA.SetData("ListLine", ReturnValues);


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

}
