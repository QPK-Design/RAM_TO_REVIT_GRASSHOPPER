using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;
using RAMDATAACCESSLib;
using Rhino.Geometry;


namespace DYNAMO_FOR_RAM_SIMPLE
{

    public class RAM_GEOMETRY_READ_WRITE : GH_Component
    {
        public override Guid ComponentGuid => throw new NotImplementedException();

        public RAM_GEOMETRY_READ_WRITE()
        {
            Instance = this;
        }

        public static RAM_GEOMETRY_READ_WRITE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            throw new NotImplementedException();
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            throw new NotImplementedException();
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            throw new NotImplementedException();
        }

        public static int GET_FLOOR_TYPE_COUNT(string FileName)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN
            IDBI.LoadDataBase2(FileName, "1");


            IFloorTypes My_floortypes = IModel.GetFloorTypes();

            int My_floortype_count = My_floortypes.GetCount();


            //CLOSE
            IDBI.CloseDatabase();

            return My_floortype_count;

        }

        public static int GET_FLOOR_TYPE_IDS(int TotalNumOfFlrTypeInListFormat, string FileName)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN
            IDBI.LoadDataBase2(FileName, "1");


            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(TotalNumOfFlrTypeInListFormat);
            int My_FloorType_ID = My_floortype.lUID;
            //CLOSE
            IDBI.CloseDatabase();

            return My_FloorType_ID;

        }

        public static int SET_FLOOR_TYPE(string FloorTypeName, string FileName)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_New_floortype = My_floortypes.Add(FloorTypeName);
            int MyFlrTypeID = My_New_floortype.lUID;

            //CLOSE
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();

            return MyFlrTypeID;

        }


        public static int GET_STORY_COUNT(string FileName)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN
            IDBI.LoadDataBase2(FileName, "1");

            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();

            //CLOSE
            IDBI.CloseDatabase();

            return My_story_count;

        }

        public static List<Rhino.Geometry.Line> GET_RAM_COL_CL(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            //CLOSE
            IDBI.CloseDatabase();
            //return list
            return ListLine;
        }

        public static List<string> GET_RAM_COL_SIZE(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            //CLOSE
            IDBI.CloseDatabase();
            //return list
            return ListLine;
        }

        public static List<int> GET_RAM_COL_ID(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            //CLOSE
            IDBI.CloseDatabase();
            //return list
            return ListLine;
        }

        public static List<Rhino.Geometry.Line> GET_RAM_BM_CL(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            return ListLine;
        }


        public static List<string> GET_RAM_BM_SIZE(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            return ListLine;
        }

        public static List<int> GET_RAM_BM_id(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            return ListLine;
        }

        public static int CREATE_FLOOR_TYPE(string FloorTypeName, string FileName)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_New_floortype = My_floortypes.Add(FloorTypeName);
            int MyFlrTypeID = My_New_floortype.lUID;

            //CLOSE
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();

            return MyFlrTypeID;

        }

        public static List<int> GET_RAM_COL_Number(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            //return list
            return ListLine;
        }


        public static List<EFRAMETYPE> GET_RAM_COL_IS_GRAV_OR_LATERAL(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<EFRAMETYPE> ListLine = new List<EFRAMETYPE>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                EFRAMETYPE My_Column_EFrameType = My_Story.GetColumns().GetAt(i).eFramingType;
                ListLine.Add(My_Column_EFrameType);
            }
            //CLOSE
            IDBI.CloseDatabase();
            //return list
            return ListLine;
        }

        public static int CREATE_RAM_STEEL_COL(int FloorIndex, string FileName, double XX, double YY, double ZTop, double ZBot)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_ColMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutColumn My_LayoutColumn = My_floortype.GetLayoutColumns().Add(My_ColMaterial, XX, YY, ZTop, ZBot);

            //CLOSE
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Col_ID = My_LayoutColumn.lUID;
            return My_New_Col_ID;
        }

        public static List<int> GET_RAM_BM_Number(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            return ListLine;
        }


        public static List<EFRAMETYPE> GET_RAM_BM_GRAV_OR_LATERAL(string FileName, int In_Story_Count)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            return ListLine;
        }

        public static int CREATE_RAM_STEEL_BM(int FloorIndex, string FileName, double StartSupportX, double StartSupportY,
            double StartSupportZ, double EndSupportX, double EndSupportY, double EndSupportZ)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            return My_New_Beam_ID;
        }

        public static int CREATE_RAM_STEEL_BRACE(int FloorIndex, string FileName,
            double StartSupportX, double StartSupportY,
            double StartSupportZ, double EndSupportX, double EndSupportY, double EndSupportZ)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
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
            return My_New_Brace_ID;
        }


        public class RAM_RESULTS : GH_Component
        {
            public RAM_RESULTS()
            {
                Instance = this;
            }

            public static RAM_RESULTS Instance
            {
                get;
                private set;
            }

            public override Guid ComponentGuid => throw new NotImplementedException();

            public static int GET_NUM_LOAD_CASES(string FileName)
            {
                RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
                RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                    RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
                RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                    RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
                RAMDATAACCESSLib.IForces2 IForces2 = (RAMDATAACCESSLib.IForces2)
                    RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IForces2_INT);

                //OPEN
                IDBI.LoadDataBase2(FileName, "1");

                EAnalysisResultType My_EAnalysisResultType = EAnalysisResultType.DefaultResultType;
                int plNumAnalysisCases = 0;

                //these methods work when accessing IFORCES2 so accessing IFORCES2 correctly?
                Type MyIForces2_Type = IForces2.GetType();
                int MyIforces2_Hashcode = IForces2.GetHashCode();
                IForces2.GetNumAnalysisCases(My_EAnalysisResultType, ref plNumAnalysisCases);

                //CLOSE
                IDBI.CloseDatabase();
                return plNumAnalysisCases;

            }

            protected override void RegisterInputParams(GH_InputParamManager pManager)
            {
                throw new NotImplementedException();
            }

            protected override void RegisterOutputParams(GH_OutputParamManager pManager)
            {
                throw new NotImplementedException();
            }

            protected override void SolveInstance(IGH_DataAccess DA)
            {
                throw new NotImplementedException();
            }
            /*           [MultiReturn(new[] { "pdDead", "pdPosLLRed", "pdPosLLNonRed", "pdPosLLStorage", "pdPosLLRoof", "pdNegLLRed",
              "pdNegLLNonRed","pdNegLLStorage","pdNegLLRoof"})]
          public static Dictionary<string, object> GET_R2R_DICT(string FileName, int BeamID)
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
              IDBI.LoadDataBase2(FileName, "1");
              /*
                  double pdDead = 0;
                  double pdPosLLRed = 0;
                  double pdPosLLNonRed = 0;
                  double pdPosLLStorage = 0;
                  double pdPosLLRoof = 0;
                  double pdNegLLRed = 0;
                  double pdNegLLNonRed = 0;
                  double pdNegLLStorage = 0;
                  double pdNegLLRoof = 0;
                  double pdLSupportX1 = 0;
                  double pdLSupportY1 = 0;
                  double pdRSupportX2 = 0;
                  double pdRSupportY2 = 0;
                  double pdReactDLL = 0;
                  double pdReactDLR = 0;
              long plNumStudSegments = 0;
              long lSizeOfArrayOfStuds = 0;
              long[] palNumStuds = new long[4];
              byte pbShored = 0;
              double pdDeckAngleLeft = 0;
              double pdDeckAngleRight = 0;
              byte pbEdgeOnLeft = 0;
              byte pbEdgeOnRight = 0;
              double pdSlabWidthLeft = 0;
              double pdSlabWidthRight = 0;
              double pdMinSlabThicknessLeft = 0;
              double pdMinSlabThicknessRight = 0;
              //IForces1.GetGrvColForcesForLCase(BeamID, ref pdDead, ref pdPosLLRed,
              //    ref pdPosLLNonRed, ref pdPosLLStorage, ref pdPosLLRoof, ref pdNegLLRed,
              //    ref pdNegLLNonRed, ref pdNegLLStorage, ref pdNegLLRoof);
              // JAM: Added refs for needed data below
              ISteelBeamDesignResult.GetNumStudsInSegments(BeamID, ref plNumStudSegments, ref lSizeOfArrayOfStuds, ref palNumStuds,
                  ref pbShored, ref pdDeckAngleLeft, ref pdDeckAngleRight, ref pbEdgeOnLeft, ref pbEdgeOnRight,
                  ref pdSlabWidthLeft, ref pdSlabWidthRight, ref pdMinSlabThicknessLeft, ref pdMinSlabThicknessRight);
              //ref pdLSupportX1, ref pdLSupportY1, ref pdRSupportX2, ref pdRSupportY2,
              //  ref pdReactDLL, ref pdReactDLR);
              IFloorTypes My_floortypes = IModel.GetFloorTypes();
              int My_floortype_count = My_floortypes.GetCount();
              //CLOSE
              IDBI.CloseDatabase();
              OutPutPorts.Add("pdDead", pdDead); OutPutPorts.Add("pdPosLLRed", pdPosLLRed);
              OutPutPorts.Add("pdPosLLNonRed", pdPosLLNonRed); OutPutPorts.Add("pdPosLLStorage", pdPosLLStorage);
              OutPutPorts.Add("pdPosLLRoof", pdPosLLRoof); OutPutPorts.Add("pdNegLLRed", pdNegLLRed);
              OutPutPorts.Add("pdNegLLNonRed", pdNegLLNonRed); OutPutPorts.Add("pdNegLLStorage", pdNegLLStorage);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);

              return OutPutPorts;
          }

          public static Dictionary<string, object> GET_GRV_COL_FORCES(string FileName, int ColumnID)
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
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
              OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);

              return OutPutPorts;
          }



          //public static GET_NUM_STUDS_IN_SEGMENTS(string FileName, int BeamID)
          //{
          //    RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
          //    RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
          //        RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
          //    RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
          //        RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
          //    RAMDATAACCESSLib.IForces1 IForces1 = (RAMDATAACCESSLib.IForces1)
          //        RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IForces_INT);
          //    Dictionary<string, object> OutPutPorts = new Dictionary<string, object>();
          //    //OPEN
          //    IDBI.LoadDataBase2(FileName, "1");
          //    int pIumStudsInSegments = 0;
          //    int ISizeOfArrayOfStuds = 0;
          //    int[] paINumStuds = [];
          //    bool pbShored = false;
          //    double pdDeckAngleLeft = 0;
          //    double pdDeckAngleRight = 0;
          //    byte pbEdgeOnLeft = 0;
          //    byte pbEdgeOnRight = 0;
          //    double pdSlabWidthLeft = 0;
          //    double pdSlabWidthRight = 0;
          //    double pdMinSlabThicknessLeft = 0;
          //    double pdMinSlabThicknessRight = 0;


          //    IBeam MyBeam = IModel.GetBeam(BeamID);
          //    IGravitySteelDesign1 gravitySteelDesign1 = MyBeam.G
          //    //DAArray segments = MyBeam.GetSteelDesignResult().GetNumStudsInSegments();


          //    //int pISegmentsSize = 0;
          //    //segments.GetSize(ref pISegmentsSize);

          //    //for (int i = 0; i < pISegmentsSize; i++)
          //    //{
          //    //    numStudsInSegments+=segments.GetProperty()
          //    //}
          //    //CLOSE
          //    IDBI.CloseDatabase();



          //    OutPutPorts.Add("totalNumStudsInSegments", numStudsInSegments);
          //    return OutPutPorts;
          //}
          */
        }

    }
}