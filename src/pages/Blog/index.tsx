import { Grid, Card, CardContent, Typography } from "@mui/material";
import { Link } from "react-router-dom";

const Blog = () => {
    return (
        <Grid container justifyContent="center" spacing={2}>
            <Grid item xs={12} md={4}>
                <Link to={"/blogs/1"}>
                    <Card sx={{ maxWidth: 345, margin: "auto" }}>
                        <CardContent>
                            <Typography
                                gutterBottom
                                variant="h5"
                                component="div"
                            >
                                {"Week 1"}
                            </Typography>
                            <Typography variant="h6" color="text.secondary">
                                {"Week 1 Summary"}
                            </Typography>
                        </CardContent>
                    </Card>
                </Link>
            </Grid>
        </Grid>
    );
};

export default Blog;
