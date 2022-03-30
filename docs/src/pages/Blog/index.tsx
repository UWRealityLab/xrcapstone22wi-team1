import { Grid, Card, CardContent, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const WEEK = 9;

const Blog = () => {
    const blogs = []
    for (let i = WEEK; i >= 1; i--) {
        blogs.push(<Grid item xs={12} md={4}>
            <Link to={"/blogs/" + i}>
                <Card sx={{ maxWidth: 345, margin: "auto" }}>
                    <CardContent>
                        <Typography
                            gutterBottom
                            variant="h5"
                            component="div"
                        >
                            {"Week " + i}
                        </Typography>
                        <Typography variant="h6" color="text.secondary">
                            {`Week ${i} Summary`}
                        </Typography>
                    </CardContent>
                </Card>
            </Link>
        </Grid>)
    }

    return (
        <Grid container justifyContent="center" spacing={2}>
            {blogs}
            
        </Grid>
    );
};

export default Blog;
