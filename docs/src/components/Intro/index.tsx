import { Box, Typography } from "@mui/material";

const Intro = () => {
    return (
        <div>
            <Typography variant="h6">
                CSE2 Virtual Tour aims to provide an immersive experience of
                having a tour inside the CSE2 building, empowering the
                incoming and prospective students of the Allen School to explore
                the Allen School and the CSE2 building virtually.
            </Typography>
            <div style={{width: "100%", textAlign: "center", margin: "1rem 0"}}>
                <iframe
                    width="560"
                    height="315"
                    src="https://www.youtube.com/embed/KlfmRKz_pjU"
                    title="YouTube video player"
                    frameBorder="0"
                    allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                    allowFullScreen
                ></iframe></div>
        </div>
    );
};

export default Intro;
