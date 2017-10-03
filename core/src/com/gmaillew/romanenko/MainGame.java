
package com.gmaillew.romanenko;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.assets.loaders.ModelLoader;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g3d.Environment;
import com.badlogic.gdx.graphics.g3d.Model;
import com.badlogic.gdx.graphics.g3d.ModelBatch;
import com.badlogic.gdx.graphics.g3d.ModelInstance;
import com.badlogic.gdx.graphics.g3d.attributes.ColorAttribute;
import com.badlogic.gdx.graphics.g3d.environment.DirectionalLight;
import com.badlogic.gdx.graphics.g3d.loader.ObjLoader;
import com.badlogic.gdx.graphics.g3d.utils.CameraInputController;
import com.badlogic.gdx.math.MathUtils;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector3;
import com.badlogic.gdx.utils.Array;
import com.badlogic.gdx.utils.TimeUtils;

import java.sql.Time;
import java.util.Iterator;

public class MainGame extends ApplicationAdapter {

    public Environment environment;

    OrthographicCamera camera;
    SpriteBatch batch;

    public ModelBatch modelBatch;
    Texture tomatoImage;
    Texture stewpanImage;
    Rectangle stewpan;
    Vector3 touchPos;
    Array<Rectangle> tomatos;
    long lastDropTime;

    public ModelInstance instance;

    Model model3D;

    @Override
    public void create() {
////////////////////////////////////
        modelBatch = new ModelBatch();
        environment = new Environment();
        environment.set(new ColorAttribute(ColorAttribute.AmbientLight, 0.4f, 0.4f, 0.4f, 1f));
        environment.add(new DirectionalLight().set(0.8f, 0.8f, 0.8f, -1f, -0.8f, -0.2f));
        //////////////////////////////
        camera = new OrthographicCamera();
        camera.setToOrtho(false, 800, 400);
        batch = new SpriteBatch();
        tomatoImage = new Texture("tomato.png");
        stewpanImage = new Texture("stewpan.jpg");
        stewpan = new Rectangle();
        stewpan.x = 800 / 2 - 64 / 2;
        stewpan.y = 20;
        stewpan.width = 64;
        stewpan.height = 64;
        touchPos = new Vector3();

        tomatos = new Array<Rectangle>();
        spawnVagetables();


        ModelLoader loader = new ObjLoader();
        model3D = loader.loadModel(Gdx.files.internal("eyeball.obj"));
        instance = new ModelInstance(model3D);

       // camController = new CameraInputController(cam);
       // Gdx.input.setInputProcessor(camController);
    }

    private void spawnVagetables() {
        Rectangle tomato = new Rectangle();
        tomato.x = MathUtils.random(0, 800 - 64);
        tomato.y = 480;
        tomato.width = 64;
        tomato.height = 64;
        tomatos.add(tomato);
        lastDropTime = TimeUtils.nanoTime();
    }

    @Override
    public void render() {
        Gdx.gl.glClearColor(0, 0, 0.2f, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
        camera.update();

        batch.setProjectionMatrix(camera.combined);
        batch.begin();
        batch.draw(stewpanImage, stewpan.x, stewpan.y);
        for(Rectangle tomato : tomatos){
            batch.draw(tomatoImage,tomato.x,tomato.y);
        }


        modelBatch.render(instance, environment);


        batch.end();

        if (Gdx.input.isTouched()) {

            touchPos.set(Gdx.input.getX(), Gdx.input.getY(), 0);
            camera.unproject(touchPos);
            stewpan.x = (int) (touchPos.x - 64 / 2);
        }

        if (Gdx.input.isKeyPressed(Input.Keys.LEFT)) stewpan.x -= 200 * Gdx.graphics.getDeltaTime();
        if (Gdx.input.isKeyPressed(Input.Keys.RIGHT)) stewpan.x += 200 * Gdx.graphics.getDeltaTime();

        if (stewpan.x < 0) stewpan.x = 0;
        if (stewpan.x > 800 - 64) stewpan.x = 800 - 64;

        if (TimeUtils.nanoTime() - lastDropTime > 1000000000) spawnVagetables();

        Iterator<Rectangle> iter = tomatos.iterator();
        while(iter.hasNext()){
            Rectangle tomato = iter.next();
            tomato.y -= 200 * Gdx.graphics.getDeltaTime();
            if(tomato.y + 64 < 0) iter.remove();
            if(tomato.overlaps(stewpan)){
                iter.remove();
            }
        }
    }

    @Override
    public void dispose() {
        batch.dispose();
        tomatoImage.dispose();
        stewpanImage.dispose();
        batch.dispose();
    }

    @Override
    public void pause() {
        super.pause();
    }
}
